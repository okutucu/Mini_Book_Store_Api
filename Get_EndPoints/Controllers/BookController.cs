using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Get_EndPoints.BookOperations.CreateBook;
using Get_EndPoints.BookOperations.DeleteBook;
using Get_EndPoints.BookOperations.GetBookDetail;
using Get_EndPoints.BookOperations.GetBooks;
using Get_EndPoints.BookOperations.UpdateBook;
using Get_EndPoints.DbOperations;
using Microsoft.AspNetCore.Mvc;
using static Get_EndPoints.BookOperations.CreateBook.CreateBookCommand;
using static Get_EndPoints.BookOperations.UpdateBook.UpdateBookCommand;

namespace Get_EndPoints.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : Controller
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Kitap listesini getiren endpoint yazıyoruz..

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            
            BookDetailViewModel result;
            try
            {
                GetBookDetailsQuery query = new GetBookDetailsQuery(_context, _mapper);
                query.BookId = id;
                GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
                validator.ValidateAndThrow(query);
                result = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result); 
          
           
        }

        //* Query ile id ile get operasyonu

        //[HttpGet]
        //public Book Get([FromQuery] string id)
        //{
        //    var book = BookList.Where(book => book.Id == int.Parse(id)).SingleOrDefault();
        //    return book;
        //}

        //POST 
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);

            try
            {
                command.Model = newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();

                validator.ValidateAndThrow(command);
                command.Handle();

                //if(result.IsValid)
                //{
                //    foreach (var item in result.Errors)
                //    {

                //    }
            //    //}else{
            //    command.Handle();
            //}

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();

        }

        //PUT

        [HttpPut("{id}")]
        public IActionResult UptadeBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.BookId = id;
                command.Model = updatedBook;
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
            return Ok();



        }


        //DELETE

        [HttpDelete("id")]

        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }
            return Ok();
        }
            


    }
}
