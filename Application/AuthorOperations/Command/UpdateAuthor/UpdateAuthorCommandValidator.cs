using FluentValidation;

namespace WebApi.Application.AuthorOperations.Command.UpdateAuthor
{
	public class UpdateAuthorCommandValidator :AbstractValidator<UpdateAuthorCommand>
	{
		public UpdateAuthorCommandValidator() 
		{
			RuleFor(x=>x.Model.Name).MinimumLength(3).NotEmpty();
			RuleFor(x=>x.Model.LastName).MinimumLength(3).NotEmpty();
			RuleFor(x => x.AuthorId).GreaterThan(0);
		}
	}
}
