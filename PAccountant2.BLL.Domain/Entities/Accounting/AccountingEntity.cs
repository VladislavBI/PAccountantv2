using PAccountant2.BLL.Domain.Entities.Account;
using PAccountant2.BLL.Domain.Entities.User;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;
using PAccountant2.BLL.Interfaces.Specifications;
using PAccountant2.BLL.Interfaces.Specifications.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using PAccountant2.BLL.Domain.Entities.Accounting.Handlers;
using PAccountant2.BLL.Domain.Entities.Currency.Handlers;

namespace PAccountant2.BLL.Domain.Entities.Accounting
{
    public class AccountingEntity
    {
        public int? Id { get; set; }

        public decimal Summ { get; set; }

        public UserEntity User { get; set; }

        public AccountingOptionsEntity Options { get; set; }

        public IEnumerable<AccountEntity> Accounts { get; set; }

        private readonly CurrencyHandler _currencyHandler;

        private readonly CurrencyFactory _currencyFactory;

        public AccountingEntity()
        {
            _currencyFactory = new CurrencyFactory();
            _currencyHandler = new CurrencyHandler();
        }

        public AccountTransferValueObject TransferMoneyBeetwenAccount(int fromId, int toId, decimal amount)
        {
            CheckMissingAccounting();

            var transferValueObject = new AccountTransferValueObject
            {
                Amount = amount,
                IdAccountFrom = fromId,
                IdAccountTo = toId
            };

            transferValueObject.TransferMoneyBeetwenAccount(Accounts);

            return transferValueObject;
        }

        public void CheckMissingAccounting()
        {
            if (!Id.HasValue)
            {
                throw new NullReferenceException($"accounting with id {Id} was not found");
            }
        }

        public decimal CalculateSumm(IEnumerable<Interfaces.DTO.DataItems.Currency.ExchangeRateDataItem> exchangeRates)
        {
            var mappedRates = exchangeRates.Select(r =>
                _currencyFactory.CreateExchangeRateValueObject(r.Buy, r.Sell, r.BaseCurrencyId, r.ResultCurrencyId)).ToList();
            var sum = default(decimal);

            foreach (var account in Accounts)
            {
                var convertedAmount = account.Amount;

                if (account.CurrencyId != Options.AccountingBaseCurrencyId)
                {
                    convertedAmount = _currencyHandler.ConvertToRate(convertedAmount, account.CurrencyId, Options.AccountingBaseCurrencyId,
                        mappedRates);
                }

                sum += convertedAmount;
            }

            return sum;
        }

        public AndSpecification<AccountBalanceDataItem> CreateSpecification(AccountFilterViewItem filters)
        {
            var amountFilter = new AccountMatchesAmount(filters);

            var compositeSpecification = new AndSpecification<AccountBalanceDataItem>(amountFilter, amountFilter);

            return compositeSpecification;
        }
    }
}
