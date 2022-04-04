using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Cart.Model;

namespace StoreServices.Api.Cart.Persistance
{
    public class CartContext : DbContext
    {
        public CartContext(DbContextOptions<CartContext> options) : base(options) { }

        public DbSet<CartSession> CartSessions { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
    }
}
