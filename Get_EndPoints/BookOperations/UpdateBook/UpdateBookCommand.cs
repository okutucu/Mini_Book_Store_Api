﻿using System.Collections.Generic;
using System.Linq;
using Get_EndPoints.DbOperations;
using Microsoft.AspNetCore.Mvc;
using System;
using Get_EndPoints.Common;
namespace Get_EndPoints.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _context;
        public int BookId { get; set; }
        public UpdateBookModel Model { get; set; }
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _context = dbContext;
        }
        public void Handle()
        {
            Book book = _context.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null) throw new InvalidOperationException("Güncellenecek Kitap Bulunamadı");

            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.Title = Model.Title != default ? Model.Title : book.Title;

            _context.SaveChanges();
        }
        public class UpdateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }


        }
    }
}
