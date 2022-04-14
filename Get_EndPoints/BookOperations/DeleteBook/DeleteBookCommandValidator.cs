using FluentValidation;


namespace Get_EndPoints.BookOperations.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
           RuleFor(command=> command.BookId).GreaterThan(0);
        }
    }
}
