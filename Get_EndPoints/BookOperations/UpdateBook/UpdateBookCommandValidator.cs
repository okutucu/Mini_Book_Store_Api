using FluentValidation;

namespace Get_EndPoints.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(comman => comman.BookId).GreaterThan(0);
            RuleFor(comman => comman.Model.GenreId).GreaterThan(0);
            RuleFor(comman => comman.Model.Title).NotEmpty().MinimumLength(4);
        }
    }
}
