using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperations.Command.CreateAuthor;
using WebApi.Application.AuthorOperations.Command.DeleteAuthor;
using WebApi.Application.AuthorOperations.Command.UpdateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.DbOperation;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorController : ControllerBase
	{
		private readonly BookStoreDbContext _dbContext;
		private readonly IMapper _mapper;

		public AuthorController(BookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetAuthors()
		{
			GetAuthorsQuery query = new GetAuthorsQuery(_dbContext, _mapper);
			var obj = query.Handle();
			return Ok(obj);
		}

		[HttpGet("{id}")]
		public IActionResult GetAuthoreDetail(int id)
		{
			GetAuthorsDetailQuery query = new GetAuthorsDetailQuery(_dbContext, _mapper);
			query.AuthorId = id;

			GetAuthorsDetailQueryValidator validator = new GetAuthorsDetailQueryValidator();
			validator.ValidateAndThrow(query);
			var obj = query.Handle();
			return Ok(obj);
		}
		[HttpPost]
		public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
		{
			CreateAuthorCommand command = new CreateAuthorCommand(_dbContext,_mapper);
			command.Model = newAuthor;
			CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
			validator.ValidateAndThrow(command);

			command.Handle();
			return Ok();
		}
		[HttpPut("{id}")]
		public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updateAuthor)
		{
			UpdateAuthorCommand command = new UpdateAuthorCommand(_dbContext);
			command.AuthorId = id;
			command.Model = updateAuthor;

			UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
			validator.ValidateAndThrow(command);

			command.Handle();
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteAuthor(int id)
		{
			DeleteAuthorCommand command = new DeleteAuthorCommand(_dbContext);
			command.AuthorId = id;

			DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
			validator.ValidateAndThrow(command);

			command.Handle();
			return Ok();
		}

	}
}
