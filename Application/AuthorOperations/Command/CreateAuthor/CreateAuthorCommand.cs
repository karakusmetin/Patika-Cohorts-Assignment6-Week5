using AutoMapper;
using WebApi.DbOperation;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Command.CreateAuthor
{
	public class CreateAuthorCommand
	{
        public CreateAuthorModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
		private readonly IMapper mapper;

		public CreateAuthorCommand(BookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			this.mapper = mapper;
		}

		public void Handle()
		{
			var command = _dbContext.Authors.FirstOrDefault(x=>x.Name+x.LastName == Model.Name+Model.LastName);
			if (command != null) 
			{
				throw new InvalidOperationException("Eklemeye Çalıştığınız yazar zaten mevcut");
			}
			command = mapper.Map<Author>(Model);
			_dbContext.Authors.Add(command);
			_dbContext.SaveChanges();
		}
	}
	public class CreateAuthorModel
	{
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
