using WebApi.DbOperation;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Command.UpdateAuthor
{
	public class UpdateAuthorCommand
	{
        public int AuthorId { get; set; }
        public UpdateAuthorModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;

		public UpdateAuthorCommand(BookStoreDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Handle()
		{
			var command=_dbContext.Authors.SingleOrDefault(x=>x.Id == AuthorId);
			if (command == null)
			{
				throw new InvalidOperationException("Yazar Bulunamadı");
			}
			var variable = _dbContext.Authors.SingleOrDefault(x => (x.Name + x.LastName).ToLower() == (Model.Name + Model.LastName).ToLower());
			if (variable != null)
			{
				throw new InvalidOperationException("Güncellenecek Kitap türü zaten mevcut.");
			}
			command.Name = Model.Name != default ? Model.Name : command.Name;
			command.LastName = Model.LastName != default ? Model.LastName : command.LastName;
			_dbContext.SaveChanges();
		}
	}
	public class UpdateAuthorModel
	{
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
