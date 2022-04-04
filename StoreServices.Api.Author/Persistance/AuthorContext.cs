using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Author.Model;

namespace StoreServices.Api.Author.Persistance
{
    public class AuthorContext : DbContext
    {
        public AuthorContext(DbContextOptions<AuthorContext> options) : base(options) { }

        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<AcademyLevel> AcademyLevels { get; set; }
    }
}
