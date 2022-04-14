using Microsoft.EntityFrameworkCore;

namespace Get_EndPoints.DbOperations
{
    public class BookStoreDbContext :DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
