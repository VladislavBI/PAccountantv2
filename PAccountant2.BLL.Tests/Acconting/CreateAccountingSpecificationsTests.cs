using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PAccountant2.BLL.Domain.Entities.Accounting;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;

namespace PAccountant2.BLL.Tests.Acconting
{
    public class CreateAccountingSpecificationsTests
    {
        private AccountingEntity _accountingEntity;

        [SetUp]
        public void Setup()
        {
            _accountingEntity = new AccountingEntity();
        }

        [Test]
        public void CreateAccountSpecification_AmountAbove100_GetAbove100Accounts()
        {
            var amountAbove = 100;
            var filtersModel = new AccountFilterViewItem
            {
                AmountAbove = amountAbove
            };
            var specification = _accountingEntity.CreateSpecification(filtersModel);

            var accountsList = new List<AccountBalanceDataItem>
            {
                new AccountBalanceDataItem
                {
                    Amount = 500
                },
                new AccountBalanceDataItem
                {
                    Amount = 10
                }
            };

            accountsList = accountsList.Where(acc => specification.IsSatisfied(acc)).ToList();

            Assert.IsTrue(accountsList.All(acc => acc.Amount > amountAbove));
        }

        [Test]
        public void CreateAccountSpecification_AmountBellow100_GetBellow100Accounts()
        {
            var amountBellow = 100;
            var filtersModel = new AccountFilterViewItem
            {
                AmountBellow = amountBellow
            };
            var specification = _accountingEntity.CreateSpecification(filtersModel);

            var accountsList = new List<AccountBalanceDataItem>
            {
                new AccountBalanceDataItem
                {
                    Amount = 500
                },
                new AccountBalanceDataItem
                {
                    Amount = 10
                }
            };

            accountsList = accountsList.Where(acc => specification.IsSatisfied(acc)).ToList();

            Assert.IsTrue(accountsList.All(acc => acc.Amount < amountBellow));
        }

        [Test]
        public void CreateAccountSpecification_AmountBetween100And600_GetBetween100And600Accounts()
        {
            var amountBellow = 600;
            var amountAbove = 100;
            var filtersModel = new AccountFilterViewItem
            {
                AmountBellow = amountBellow,
                AmountAbove = amountAbove
            };
            var specification = _accountingEntity.CreateSpecification(filtersModel);

            var accountsList = new List<AccountBalanceDataItem>
            {
                new AccountBalanceDataItem
                {
                    Amount = 500
                },
                new AccountBalanceDataItem
                {
                    Amount = 10
                }
            };

            accountsList = accountsList.Where(acc => specification.IsSatisfied(acc)).ToList();

            Assert.IsTrue(accountsList.All(acc => acc.Amount < amountBellow && acc.Amount > amountAbove));
        }
    }
}