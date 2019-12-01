using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PAccountant2.BLL.Domain.Entities.Account;
using PAccountant2.BLL.Domain.Enum;
using PAccountant2.BLL.Interfaces.Account;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Currency;
using PAccountant2.BLL.Interfaces.Specifications;

namespace PAccountant2.BLL.Tests.Acconting
{
    public class AccountTests
    {
        private AccountEntity _accountEntity;
        private Mock<IAccountDataService> _accountDataService;

        private const int BaseCurrencyId = 1;

        [SetUp]
        public void Setup()
        {
            _accountEntity = new AccountEntity();
            _accountEntity.CurrencyId = BaseCurrencyId;
            _accountDataService = new Mock<IAccountDataService>();
        }

        [Test]
        public void AddMoney_Add100MoneySameRate_AccountAmountIs100()
        {
            var moneyToAdd = 100;
            // ReSharper disable once CollectionNeverUpdated.Local
            var exchangeRates = new List<ExchangeRateDataItem>
            {
                new ExchangeRateDataItem()
            };
            var currencyId = BaseCurrencyId;

            _accountEntity.PutMoneyToThisAccount(moneyToAdd, currencyId, exchangeRates);
            Assert.AreEqual(_accountEntity.Amount, moneyToAdd);
        }

        [Test]
        public void WithdrawMoney_Withdraw50MoneySameRate_AccountAmountIs50()
        {
            var moneyToAdd = 250;
            var moneyToWithdraw = 150;
            var newAmount = moneyToAdd - moneyToWithdraw;
            // ReSharper disable once CollectionNeverUpdated.Local
            var exchangeRates = new List<ExchangeRateDataItem>
            {
                new ExchangeRateDataItem()
            };

            var currencyId = BaseCurrencyId;

            _accountEntity.PutMoneyToThisAccount(moneyToAdd, currencyId, exchangeRates);
            _accountEntity.WithdrawMoneyFromThisAccount(moneyToWithdraw, currencyId, exchangeRates);

            Assert.AreEqual(_accountEntity.Amount, newAmount);
        }

        [Test]
        public void AddMoney_Add100MoneySameRate_NewOperationIsCreated()
        {
            var moneyToAdd = 200;
            // ReSharper disable once CollectionNeverUpdated.Local
            var exchangeRates = new List<ExchangeRateDataItem>
            {
                new ExchangeRateDataItem()
            };
            var currencyId = BaseCurrencyId;

            var newOperation = _accountEntity.PutMoneyToThisAccount(moneyToAdd, currencyId, exchangeRates);

            Assert.AreEqual(newOperation.Amount, moneyToAdd);
            Assert.AreEqual(newOperation.OperationType, AccountBalanceChangeType.Put);
            Assert.AreEqual(newOperation.Currency.Id, currencyId);
        }

        [Test]
        public void WithdrawMoney_Withdraw50MoneySameRate_NewOperationIsCreated()
        {
            var moneyToAdd = 1000;
            var moneyToWithdraw = 520;
            // ReSharper disable once CollectionNeverUpdated.Local
            var exchangeRates = new List<ExchangeRateDataItem>
            {
                new ExchangeRateDataItem()
            };
            var currencyId = BaseCurrencyId;

            _accountEntity.PutMoneyToThisAccount(moneyToAdd, currencyId, exchangeRates);
            var newOperation = _accountEntity.WithdrawMoneyFromThisAccount(moneyToWithdraw, currencyId, exchangeRates);

            Assert.AreEqual(newOperation.Amount, moneyToWithdraw);
            Assert.AreEqual(newOperation.OperationType, AccountBalanceChangeType.Withdraw);
            Assert.AreEqual(newOperation.Currency.Id, currencyId);
        }

        [Test]
        public async Task GetAccountHistoryFilteredAsync_WithdrawAnsPutOperations_OperationsHaveCorrectData()
        {
            int oper1Amount, oper2Type, oper2CurId;
            DateTime oper1Date;
            AccountWithHistotyDataItem accWithHistory;
            AcHistoyFilteredSetup(out oper1Amount, out oper1Date, out oper2Type, out oper2CurId, out accWithHistory);

            var result = await _accountEntity.GetAccountHistoryFilteredAsync(null, _accountDataService.Object);

            Assert.AreEqual(accWithHistory.AccountOperations.Count(), result.Count());

            var firstOperation = result.FirstOrDefault();
            var lastOperation = result.LastOrDefault();

            Assert.AreEqual(firstOperation.Amount, oper1Amount);
            Assert.AreEqual(firstOperation.Date, oper1Date);
            Assert.AreEqual((int)lastOperation.OperationType, oper2Type);
            Assert.AreEqual(lastOperation.Currency.Id, oper2CurId);
        }

        private void AcHistoyFilteredSetup(out int oper1Amount, out DateTime oper1Date, out int oper2Type, out int oper2CurId, out AccountWithHistotyDataItem accWithHistory)
        {
            oper1Amount = 100;
            oper1Date = DateTime.Now;
            var oper1Type = 1;
            var oper1CurId = BaseCurrencyId;


            var oper2Amount = 200;
            var oper2Date = DateTime.Now;
            oper2Type = 2;
            oper2CurId = 2;
            accWithHistory = new AccountWithHistotyDataItem
            {
                AccountOperations = new List<AccountOperationDataItem>
                {
                    new AccountOperationDataItem
                    {
                        Amount = oper1Amount,
                        Date = oper1Date,
                        OperationType = oper1Type,
                        Id = 1,
                        CurrencyId = oper1CurId
                    },
                    new AccountOperationDataItem
                    {
                        Amount = oper2Amount,
                        Date = oper2Date,
                        OperationType = oper2Type,
                        Id = 2,
                        CurrencyId = oper2CurId
                    }
                }
            };
            _accountDataService.Setup(x => x.GetHistoryAsync(It.IsAny<int>(), It.IsAny<ISpecification<AccountHistoryFiltersDataItem>>()))
                .Returns(Task.FromResult(accWithHistory));
        }
    }
}