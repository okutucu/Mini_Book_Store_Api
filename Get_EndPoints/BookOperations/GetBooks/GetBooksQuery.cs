using System.Collections.Generic;
using System.Linq;
using Get_EndPoints.DbOperations;
using Microsoft.AspNetCore.Mvc;
using System;
using Get_EndPoints.Common;
using AutoMapper;

namespace Get_EndPoints.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel>  Handle()
        {
            List<Book> bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();

            List<BooksViewModel> vm = _mapper.Map < List < BooksViewModel >>(bookList);

            //foreach (Book book in bookList)
            //{
            //    vm.Add(new BooksViewModel()
            //    {
            //        Title=book.Title,
            //        Genre = ((GenreEnum)book.GenreId).ToString(),
            //        PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyyy"),
            //        PageCount = book.PageCount
            //    });
            //}
            return vm;
        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
