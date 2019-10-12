using Microsoft.EntityFrameworkCore;
using PAccountant2.DAL.DBO.Constants;
using PAccountant2.DAL.DBO.Entities;

namespace PAccountant2.DAL.Context
{
    public class PaccountantContext: DbContext
    {
        public DbSet<UserDbo> Users { get; set; }

        public PaccountantContext(DbContextOptions options): base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDbo>().ToTable(TablesNames.User);
            modelBuilder.Entity<UserDbo>().HasKey(x => x.Email);
        }
    }
}
