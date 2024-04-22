using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OganiShopMVC.Models;


namespace OganiShopMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
          //  SeedDB.SeedData(this);

        }
        public virtual DbSet<New> News { get; set; }
        public virtual DbSet<CategoryNew> CategoryNews { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<Order> Oders { get; set; }
        public virtual DbSet<OrderDetail> OderDetails { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<Users> User { get; set; }
        public virtual DbSet<config> Configs { get; set; }

        public virtual DbSet<CustomUser> CustomUsers { get; set; }

        public virtual DbSet<ShoppingCartItem> ShopingCartItems { get; set;}

        // public virtual DbSet<Role> Roles { get; set; }
    }
}