using FluentValidation;

namespace Get_EndPoints.BookOperations.GetBookDetail
{
    public class GetBookDetailQueryValidator :AbstractValidator<GetBookDetailsQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(query => query.BookId).GreaterThan(0);
        }
    }
}
