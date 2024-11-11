using FashionFlare.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FashionFlare.EntityFramework
{
    public class Context : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Category> Categories { get; set; }

        public Context(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>()
                 .HasMany(c => c.Products)
                 .WithOne(p => p.Category)
                 .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<User>()
              .HasOne<Cart>()
              .WithOne(c => c.User)
              .HasForeignKey<Cart>(c => c.UserId);

            // Configure a one-to-many relationship between Cart and CartItems
            modelBuilder.Entity<Cart>()
                .HasMany(c => c.CartItems)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.ApplyConfiguration(new UserRoles());
        }

    }
}
