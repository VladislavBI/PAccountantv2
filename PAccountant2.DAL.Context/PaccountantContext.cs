﻿using Microsoft.EntityFrameworkCore;
using PAccountant2.BLL.Domain.Entities;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Currency;
using PAccountant2.DAL.DBO.Constants;
using PAccountant2.DAL.DBO.Entities;
using PAccountant2.DAL.DBO.Entities.Accounting;
using PAccountant2.DAL.DBO.Entities.Currency;
using PAccountant2.DAL.DBO.Entities.Investment;

namespace PAccountant2.DAL.Context
{
    public class PaccountantContext: DbContext
    {
        public DbSet<UserDbo> Users { get; set; }

        public DbSet<AccountDbo> Accounts { get; set; }

        public DbSet<AccountOperationDbo> AccountsOperations { get; set; }

        public DbSet<AccountingDbo> Accountings { get; set; }

        public DbSet<ContragentDbo> Contragents { get; set; }

        public DbSet<InvestmentDbo> Investments { get; set; }

        public DbSet<CurrencyDbo> Currencies { get; set; }

        public DbSet<ExchangeRateDbo> ExchangeRates { get; set; }

        public PaccountantContext(DbContextOptions options): base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDbo>().ToTable(TablesNames.User);
            modelBuilder.Entity<UserDbo>().HasKey(x => x.Email);
            modelBuilder.Entity<UserDbo>().HasOne(x => x.Accounting).WithOne(x => x.User).HasForeignKey<AccountingDbo>(x => x.UserEmail);

            modelBuilder.Entity<AccountingDbo>().ToTable(TablesNames.Accounting);
            modelBuilder.Entity<AccountingDbo>().Property(x => x.Id).UseSqlServerIdentityColumn();
            modelBuilder.Entity<AccountingDbo>().HasMany(x => x.Accounts).WithOne(x => x.Accounting).HasForeignKey(x => x.AccountingId);
            modelBuilder.Entity<AccountingDbo>().HasMany(x => x.Investments).WithOne(x => x.Accounting).HasForeignKey(x => x.AccountingId);


            modelBuilder.Entity<AccountingOptionsDbo>().ToTable(TablesNames.AccountingOptions);
            modelBuilder.Entity<AccountingOptionsDbo>().HasKey(x => x.AccountingId);
            modelBuilder.Entity<AccountingOptionsDbo>().HasOne(x => x.Accounting).WithOne(x => x.Options).HasForeignKey<AccountingOptionsDbo>(x => x.AccountingId);
            modelBuilder.Entity<AccountingOptionsDbo>().HasOne(x => x.AccountingBaseCurrency).WithMany(x => x.AccountingOptions).HasForeignKey(x => x.AccountingBaseCurrencyId);

            modelBuilder.Entity<AccountDbo>().ToTable(TablesNames.Account);
            modelBuilder.Entity<AccountDbo>().Property(x => x.Id).UseSqlServerIdentityColumn();
            modelBuilder.Entity<AccountDbo>().HasMany(entity => entity.AccountHistory).WithOne(entity => entity.Account)
                .HasForeignKey(prop => prop.AccountId);

            modelBuilder.Entity<AccountOperationDbo>().ToTable(TablesNames.AccountOperation);
            modelBuilder.Entity<AccountOperationDbo>().Property(prop => prop.Id).UseSqlServerIdentityColumn();

            modelBuilder.Entity<InvestmentDbo>().ToTable(TablesNames.Investment);
            modelBuilder.Entity<InvestmentDbo>().Property(inv => inv.Id).UseSqlServerIdentityColumn();
            modelBuilder.Entity<InvestmentDbo>().HasMany(x => x.Operations).WithOne(x => x.Investment).HasForeignKey(x => x.InvestmentId);

            modelBuilder.Entity<InvestmentOperationDbo>().ToTable(TablesNames.InvestmentOperation);
            modelBuilder.Entity<InvestmentOperationDbo>().Property(prop => prop.Id).UseSqlServerIdentityColumn();

            modelBuilder.Entity<ContragentDbo>().ToTable(TablesNames.Contragent);
            modelBuilder.Entity<ContragentDbo>().Property(prop => prop.Id).UseSqlServerIdentityColumn();
            modelBuilder.Entity<ContragentDbo>().HasMany(prop => prop.AccountOperations).WithOne(prop => prop.Contragent).HasForeignKey(prop => prop.ContragentId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ContragentDbo>().HasMany(prop => prop.InvestmentOperations).WithOne(prop => prop.Contragent).HasForeignKey(prop => prop.ContragentId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CurrencyDbo>().ToTable(TablesNames.Currency);
            modelBuilder.Entity<CurrencyDbo>().Property(cur => cur.Id).UseSqlServerIdentityColumn();
            modelBuilder.Entity<CurrencyDbo>().HasMany(cur => cur.AccountOperations).WithOne(acc => acc.Currency).HasForeignKey(acc => acc.CurrencyId);
            modelBuilder.Entity<CurrencyDbo>().HasMany(cur => cur.InvestmentOperations).WithOne(acc => acc.Currency).HasForeignKey(acc => acc.CurrencyId);

            modelBuilder.Entity<ExchangeRateDbo>().ToTable(TablesNames.ExchangeRate);
            modelBuilder.Entity<ExchangeRateDbo>().Property(cur => cur.Id).UseSqlServerIdentityColumn();
            modelBuilder.Entity<ExchangeRateDbo>().HasOne(rate => rate.BaseCurrency).WithMany(cur => cur.BaseCurrenciesRates).HasForeignKey(rate => rate.BaseCurrencyId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ExchangeRateDbo>().HasOne(rate => rate.ResultCurrency).WithMany(acc => acc.ResultCurrenciesRates).HasForeignKey(rate => rate.ResultCurrencyId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
