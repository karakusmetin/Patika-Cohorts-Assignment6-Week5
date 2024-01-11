using FluentValidation;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
	public class GetAuthorsDetailQueryValidator : AbstractValidator<GetAuthorsDetailQuery>
	{
		public GetAuthorsDetailQueryValidator()
		{
			RuleFor(x => x.AuthorId).GreaterThan(0);
		}
	}
}
