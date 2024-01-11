using AutoMapper;
using WebApi.DbOperation;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
	public class GetAuthorsDetailQuery
	{
		public int AuthorId { get; set; }

		private readonly BookStoreDbContext _dbContext;

		private readonly IMapper _mapper;

		public GetAuthorsDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public AuthorDetailView Handle()
		{
			var command = _dbContext.Authors.Where(book => book.Id == AuthorId).SingleOrDefault();
			if (command == null)
			{
				throw new InvalidOperationException("Aranan Yazar Bulunamadı");
			}
			AuthorDetailView returnobj = _mapper.Map<AuthorDetailView>(command);
			return returnobj;
		}
	}

	public class AuthorDetailView
	{
		public string Name { get; set; }
		public string LastName { get; set; }
		public DateTime DateofBirth { get; set; }

	} 
}
