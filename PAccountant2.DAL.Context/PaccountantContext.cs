using Microsoft.EntityFrameworkCore;
using PAccountant2.DAL.DBO.Constants;
using PAccountant2.DAL.DBO.Entities;
using PAccountant2.DAL.DBO.Entities.Investment;

namespace PAccountant2.DAL.Context
{
    public class PaccountantContext: DbContext
    {
        public DbSet<UserDbo> Users { get; set; }

        public DbSet<AccountDbo> Accounts { get; set; }

        public DbSet<AccountOperationDbo> AccountsOperations { get; set; }

        public DbSet<AccountingDbo> Accountings { get; set; }

        public PaccountantContext(DbContextOptions options): base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDbo>().ToTable(TablesNames.User);
            modelBuilder.Entity<UserDbo>().HasKey(x => x.Email);
            modelBuilder.Entity<UserDbo>().HasOne(x => x.Accounting).WithOne(x => x.User).HasForeignKey<AccountingDbo>(x => x.UserEmail);


            modelBuilder.Entity<AccountingDbo>().ToTable(TablesNames.Accounting);
            modelBuilder.Entity<AccountingDbo>().HasKey(x => x.Id);
            modelBuilder.Entity<AccountingDbo>().HasMany(x => x.Accounts).WithOne(x => x.Accounting).HasForeignKey(x => x.AccountingId);
            modelBuilder.Entity<AccountingDbo>().HasMany(x => x.Investments).WithOne(x => x.Accounting).HasForeignKey(x => x.AccountingId);

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


        }
    }
}
