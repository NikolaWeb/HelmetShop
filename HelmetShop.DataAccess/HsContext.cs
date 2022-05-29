using HelmetShop.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace HelmetShop.DataAccess
{
    public class HsContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<UserUseCase>().HasKey(x => new {x.UserId, x.UseCaseId});
            base.OnModelCreating(modelBuilder);
        }

        //connection string is hardcoded
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=MUSCLEPLUS\SQLEXPRESS;Initial Catalog=HelmetShop;Integrated Security=True");
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
      
    }
}
