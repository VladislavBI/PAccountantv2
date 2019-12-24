using Microsoft.EntityFrameworkCore;
using PAccountant2.Common.Constants;
using PAccountant2.DAL.DBO.Constants;
using PAccountant2.DAL.DBO.Entities;
using PAccountant2.DAL.DBO.Entities.Account;
using PAccountant2.DAL.DBO.Entities.Accounting;
using PAccountant2.DAL.DBO.Entities.Credit;
using PAccountant2.DAL.DBO.Entities.Currency;
using PAccountant2.DAL.DBO.Entities.Investment;
using PAccountant2.DAL.DBO.Entities.WheelOfLife;
using PAccountant2.DAL.DBO.ManyToMany;

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

        public DbSet<WheelOfLifeElementDbo> WheelOfLifeElements { get; set; }
        public DbSet<WheelOfLifeMementoDbo> WheelOfLifeMementos { get; set; }
        public DbSet<WheelOfLifeProblemDbo> WheelOfLifeProblems { get; set; }
        public DbSet<WheelOfLifePlanDbo> WheelOfLifePlans { get; set; }

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
            modelBuilder.Entity<AccountDbo>().Property(x => x.Name).HasMaxLength(StringLengthConsts.NameLength);
            modelBuilder.Entity<AccountDbo>().HasMany(entity => entity.AccountHistory).WithOne(entity => entity.Account)
                .HasForeignKey(prop => prop.AccountId);

            modelBuilder.Entity<AccountOperationDbo>().ToTable(TablesNames.AccountOperation);
            modelBuilder.Entity<AccountOperationDbo>().Property(prop => prop.Id).UseSqlServerIdentityColumn();
            modelBuilder.Entity<AccountOperationDbo>().Property(prop => prop.CurrencyId).HasDefaultValue(1);

            modelBuilder.Entity<InvestmentDbo>().ToTable(TablesNames.Investment);
            modelBuilder.Entity<InvestmentDbo>().Property(inv => inv.Id).UseSqlServerIdentityColumn();
            modelBuilder.Entity<InvestmentDbo>().HasMany(x => x.Operations).WithOne(x => x.Investment).HasForeignKey(x => x.InvestmentId);

            modelBuilder.Entity<InvestmentOperationDbo>().ToTable(TablesNames.InvestmentOperation);
            modelBuilder.Entity<InvestmentOperationDbo>().Property(prop => prop.Id).UseSqlServerIdentityColumn();

            modelBuilder.Entity<CreditDbo>().ToTable(TablesNames.Credit);
            modelBuilder.Entity<CreditDbo>().Property(inv => inv.Id).UseSqlServerIdentityColumn();
            modelBuilder.Entity<CreditDbo>().HasMany(x => x.Operations).WithOne(x => x.Credit).HasForeignKey(x => x.CreditId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CreditOperationDbo>().ToTable(TablesNames.CreditOperation);
            modelBuilder.Entity<CreditOperationDbo>().Property(prop => prop.Id).UseSqlServerIdentityColumn();

            modelBuilder.Entity<ContragentDbo>().ToTable(TablesNames.Contragent);
            modelBuilder.Entity<ContragentDbo>().Property(prop => prop.Id).UseSqlServerIdentityColumn();
            modelBuilder.Entity<ContragentDbo>().HasMany(prop => prop.AccountOperations).WithOne(prop => prop.Contragent).HasForeignKey(prop => prop.ContragentId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CurrencyDbo>().ToTable(TablesNames.Currency);
            modelBuilder.Entity<CurrencyDbo>().Property(cur => cur.Id).UseSqlServerIdentityColumn();
            modelBuilder.Entity<CurrencyDbo>().HasMany(cur => cur.AccountOperations).WithOne(acc => acc.Currency).HasForeignKey(acc => acc.CurrencyId);
            modelBuilder.Entity<CurrencyDbo>().HasMany(cur => cur.Accounts).WithOne(acc => acc.Currency).HasForeignKey(acc => acc.CurrencyId).OnDelete(DeleteBehavior.Restrict); ;
            modelBuilder.Entity<CurrencyDbo>().HasMany(cur => cur.InvestmentOperations).WithOne(acc => acc.Currency).HasForeignKey(acc => acc.CurrencyId);
            modelBuilder.Entity<CurrencyDbo>().HasMany(cur => cur.CreditOperations).WithOne(acc => acc.Currency).HasForeignKey(acc => acc.CurrencyId);
            modelBuilder.Entity<CurrencyDbo>().HasMany(cur => cur.Investments).WithOne(acc => acc.Currency).HasForeignKey(acc => acc.CurrencyId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExchangeRateDbo>().ToTable(TablesNames.ExchangeRate);
            modelBuilder.Entity<ExchangeRateDbo>().Property(cur => cur.Id).UseSqlServerIdentityColumn();
            modelBuilder.Entity<ExchangeRateDbo>().HasOne(rate => rate.BaseCurrency).WithMany(cur => cur.BaseCurrenciesRates).HasForeignKey(rate => rate.BaseCurrencyId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ExchangeRateDbo>().HasOne(rate => rate.ResultCurrency).WithMany(acc => acc.ResultCurrenciesRates).HasForeignKey(rate => rate.ResultCurrencyId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WheelOfLifeElementDbo>().ToTable(TablesNames.WheelOfLifeElement);
            modelBuilder.Entity<WheelOfLifeElementDbo>().Property(el => el.Id).UseSqlServerIdentityColumn();
            modelBuilder.Entity<WheelOfLifeElementDbo>().HasMany(el => el.Problems).WithOne(pr => pr.Element).HasForeignKey(pr => pr.ElementId);

            modelBuilder.Entity<WheelOfLifeMementoDbo>().ToTable(TablesNames.WheelOfLifeMemento);
            modelBuilder.Entity<WheelOfLifeMementoDbo>().Property(m => m.Id).UseSqlServerIdentityColumn();


            modelBuilder.Entity<WheelOfLifeProblemDbo>().ToTable(TablesNames.WheelOfLifeProblem);
            modelBuilder.Entity<WheelOfLifeProblemDbo>().Property(pr => pr.Id).UseSqlServerIdentityColumn();
            modelBuilder.Entity<WheelOfLifeProblemDbo>().HasMany(pr => pr.Plans).WithOne(pl => pl.Problem).HasForeignKey(pl => pl.ProblemId);

            modelBuilder.Entity<WheelOfLifePlanDbo>().ToTable(TablesNames.WheelOfLifePlan);
            modelBuilder.Entity<WheelOfLifePlanDbo>().Property(pl => pl.Id).UseSqlServerIdentityColumn();

            modelBuilder.Entity<WheelOfLifeElementMementoDbo>().ToTable(TablesNames.WheelOfLifeElementMemento);
            modelBuilder.Entity<WheelOfLifeElementMementoDbo>().Property(em => em.Id).UseSqlServerIdentityColumn();
            modelBuilder.Entity<WheelOfLifeElementMementoDbo>()
                .HasOne(em => em.WheelElement)
                .WithMany(el => el.ElementMementos)
                .HasForeignKey(em => em.WheelElementId)
                .HasConstraintName("ElementManyToManyFK");
            modelBuilder.Entity<WheelOfLifeElementMementoDbo>()
                .HasOne(em => em.WheelMemento)
                .WithMany(m => m.ElementMementos)
                .HasForeignKey(em => em.WheelMementoId)
                .HasConstraintName("MementoManyToManyFK");
        }
    }
}
