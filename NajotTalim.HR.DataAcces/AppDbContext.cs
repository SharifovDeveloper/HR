using Microsoft.EntityFrameworkCore;
using NajotTalim.HR.DataAcces.Entities;

namespace NajotTalim.HR.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employee>()
            //    .HasOne(e => e)
            //    .WithOne() // One-to-one relationship
            //    .HasForeignKey<Employee>(e => e.AddressId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
