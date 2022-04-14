using System.Collections.Generic;
using System.Linq;
using Get_EndPoints.DbOperations;
using Microsoft.AspNetCore.Mvc;
using System;
using Get_EndPoints.Common;

namespace Get_EndPoints.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            Book book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null) throw new InvalidOperationException("Silinecek Kitap bulunamadı");

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}
