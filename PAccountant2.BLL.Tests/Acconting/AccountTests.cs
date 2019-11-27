using System.Linq;
using NUnit.Framework;
using PAccountant2.BLL.Domain.Entities.Account;
using PAccountant2.BLL.Domain.Entities.Accounting;
using PAccountant2.BLL.Domain.Enum;

namespace Tests
{
    public class AccountTests
    {
        private AccountEntity accountEntity;

        [SetUp]
        public void Setup()
        {
            accountEntity = new AccountEntity();
        }

        [Test]
        public void AddMoney_Add100Money_AccountAmountIs100()
        {
            var moneyToAdd = 100;

            accountEntity.PutMoney(moneyToAdd);
            Assert.AreEqual(accountEntity.Amount, moneyToAdd);
        }

        [Test]
        public void WithdrawMoney_Withdraw50Money_AccountAmountIs50()
        {
            var moneyToAdd = 250;
            var moneyToWithdraw = 150;
            var newAmount = moneyToAdd - moneyToWithdraw;

            accountEntity.PutMoney(moneyToAdd);
            accountEntity.WithdrawMoney(moneyToWithdraw);

            Assert.AreEqual(accountEntity.Amount, newAmount);
        }

        [Test]
        public void AddMoney_Add100Money_NewOperationIsCreated()
        {
            var moneyToAdd = 200;

            accountEntity.PutMoney(moneyToAdd);
            var newOperation = accountEntity.AccountOperations.FirstOrDefault();

            Assert.AreEqual(newOperation.Amount, moneyToAdd);
            Assert.AreEqual(newOperation.OperationType, AccountBalanceChangeType.Put);
        }

        [Test]
        public void WithdrawMoney_Withdraw50Money_NewOperationIsCreated()
        {
            var moneyToAdd = 1000;
            var moneyToWithdraw = 520;

            accountEntity.PutMoney(moneyToAdd);
            accountEntity.WithdrawMoney(moneyToWithdraw);

            var newOperation = accountEntity.AccountOperations.LastOrDefault();

            Assert.AreEqual(newOperation.Amount, moneyToWithdraw);
            Assert.AreEqual(newOperation.OperationType, AccountBalanceChangeType.Withdraw);
        }
    }
}