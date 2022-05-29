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
            modelBuilder.Entity<CartItem>().HasKey(x => new { x.ProductId, x.OrderId });
            modelBuilder.Entity<ProductCategory>().HasKey(x => new { x.ProductId, x.CategoryId});
            base.OnModelCreating(modelBuilder);
        }

        //connection string is hardcoded
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=MUSCLEPLUS\SQLEXPRESS;Initial Catalog=HelmetShopDb;Integrated Security=True");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; } 
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
    }
}
