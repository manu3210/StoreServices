using Microsoft.EntityFrameworkCore;
using StoreServices.Api.ShoppingCart.Model;

namespace StoreServices.Api.ShoppingCart.Persistance
{
    public class CartContext : DbContext
    {
        public CartContext(DbContextOptions options) : base(options) { }

        public DbSet<CartSession> CartSessions { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
    }
}
