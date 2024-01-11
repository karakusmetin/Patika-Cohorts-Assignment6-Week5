using FluentValidation;

namespace WebApi.Application.AuthorOperations.Command.CreateAuthor
{
	public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
	{
		public CreateAuthorCommandValidator() 
		{
			RuleFor(x=>x.Model.Name).NotEmpty();
			RuleFor(x=>x.Model.LastName).NotEmpty();
			RuleFor(x => x.Model.DateOfBirth.Date).NotEmpty().LessThan(DateTime.Now.Date);


		}
	}
}
