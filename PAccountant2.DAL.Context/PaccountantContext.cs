using Microsoft.EntityFrameworkCore;
using PAccountant2.DAL.DBO.Constants;
using PAccountant2.DAL.DBO.Entities;

namespace PAccountant2.DAL.Context
{
    public class PaccountantContext: DbContext
    {
        public DbSet<UserDbo> Users { get; set; }

        public DbSet<AccountDbo> Accounts { get; set; }


        public PaccountantContext(DbContextOptions options): base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDbo>().ToTable(TablesNames.User);
            modelBuilder.Entity<UserDbo>().HasKey(x => x.Email);
            modelBuilder.Entity<UserDbo>().HasMany(x => x.Accounts).WithOne(x => x.User).HasForeignKey(x => x.UserId);

            modelBuilder.Entity<AccountDbo>().ToTable(TablesNames.Account);
            modelBuilder.Entity<AccountDbo>().Property(x => x.Id).UseSqlServerIdentityColumn();

        }
    }
}
