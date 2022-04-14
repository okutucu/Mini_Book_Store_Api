using AutoMapper;
using Get_EndPoints.BookOperations.GetBookDetail;
using Get_EndPoints.BookOperations.GetBooks;
using static Get_EndPoints.BookOperations.CreateBook.CreateBookCommand;

namespace Get_EndPoints.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src=> ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }
    }
}
