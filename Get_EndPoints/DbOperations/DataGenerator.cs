using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Get_EndPoints.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(
                    new Book
                    {
                       
                        Title = "Lean Startup",
                        GenreId = 1, // Personal Growth
                        PageCount = 200,
                        PublishDate = new System.DateTime(2001, 06, 12)
                    },
                    new Book
                    {
                        
                        Title = "Herlan",
                        GenreId = 2, // Science Fiction
                        PageCount = 250,
                        PublishDate = new System.DateTime(2010, 05, 23)
                    },
                    new Book
                    {
                        
                        Title = "Dune",
                        GenreId = 2, // Science Fiction
                        PageCount = 200,
                        PublishDate = new System.DateTime(2001, 12, 23)
                    });

                context.SaveChanges();
            }


        }
    }
}
