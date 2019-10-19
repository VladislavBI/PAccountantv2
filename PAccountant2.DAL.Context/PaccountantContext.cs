using Microsoft.EntityFrameworkCore;
using PAccountant2.DAL.DBO.Constants;
using PAccountant2.DAL.DBO.Entities;

namespace PAccountant2.DAL.Context
{
    public class PaccountantContext: DbContext
    {
        public DbSet<UserDbo> Users { get; set; }

        public DbSet<AccountDbo> Accounts { get; set; }

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

            modelBuilder.Entity<AccountDbo>().ToTable(TablesNames.Account);
            modelBuilder.Entity<AccountDbo>().Property(x => x.Id).UseSqlServerIdentityColumn();
            modelBuilder.Entity<AccountDbo>().HasMany(entity => entity.AccountHistory).WithOne(entity => entity.Account)
                .HasForeignKey(prop => prop.AccountId);


            modelBuilder.Entity<AccountOperationDbo>().ToTable(TablesNames.AccountOperation);
            modelBuilder.Entity<AccountOperationDbo>().Property(prop => prop.Id).UseSqlServerIdentityColumn();

        }
    }
}
