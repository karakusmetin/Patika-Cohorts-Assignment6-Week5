using AutoMapper;
using WebApi.DbOperation;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{
	public class GetAuthorsQuery
	{
		private readonly BookStoreDbContext _dbContext;

		private readonly IMapper _mapper;

		public GetAuthorsQuery(BookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public List<AuthorsView> Handle()
		{
			var command = _dbContext.Authors.OrderBy(x=>x.Id);
			List<AuthorsView> returnobj = _mapper.Map<List<AuthorsView>>(command);
			return returnobj;
		}
	}

	public class AuthorsView
	{
		public string Name { get; set; }
		public string LastName { get; set; }
		public DateTime DateofBirth { get; set; }

	}
}
