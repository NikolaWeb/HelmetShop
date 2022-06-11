using HelmetShop.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace HelmetShop.DataAccess
{
    public class HsContext : DbContext
    {
        
        public HsContext(DbContextOptions options) : base(options)
        {

        }
        
        //public HsContext()
        //{

        //}
        
        public IApplicationUser User { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<UserUseCase>().HasKey(x => new {x.UserId, x.UseCaseId});
            modelBuilder.Entity<CartItem>().HasKey(x => new { x.ProductId, x.OrderId });
            modelBuilder.Entity<ProductCategory>().HasKey(x => new { x.ProductId, x.CategoryId});
            //modelBuilder.Entity<Order>().Property(x => x.CreatedAt).HasDefaultValue("GETDATE()");
            base.OnModelCreating(modelBuilder);
        }

        //connection string is in appsettings

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=MUSCLEPLUS\SQLEXPRESS;Initial Catalog=HelmetShopDatabase;Integrated Security=True");
        //}


        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.UtcNow;
                            e.UpdatedBy = User?.Identity;
                            break;
                    }
                }
            }

            return base.SaveChanges();
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
