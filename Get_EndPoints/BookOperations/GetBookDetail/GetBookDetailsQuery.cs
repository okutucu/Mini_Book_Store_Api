using System.Collections.Generic;
using System.Linq;
using Get_EndPoints.DbOperations;
using Microsoft.AspNetCore.Mvc;
using System;
using Get_EndPoints.Common;
using AutoMapper;

namespace Get_EndPoints.BookOperations.GetBookDetail
{
    public class GetBookDetailsQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public int BookId { get; set; }

        public GetBookDetailsQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            Book book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
            if (book is null)
                throw new InvalidOperationException("Kitap Bulunamadı !");
            BookDetailViewModel vm = _mapper.Map<Book, BookDetailViewModel>(book); 
            //vm.Title = book.Title;
            //vm.PageCount = book.PageCount;
            //vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");
            //vm.Genre = ((GenreEnum)book.GenreId).ToString();
            return vm;
        }
    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }

}
