using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Book.Model;

namespace StoreServices.Api.Book.Persistance
{
    public class BookContext : DbContext
    {
        public BookContext() { }
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        public virtual DbSet<BookMaterial> Books { get; set; }
    }
}
