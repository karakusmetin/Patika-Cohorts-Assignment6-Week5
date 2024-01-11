using WebApi.DbOperation;

namespace WebApi.Application.AuthorOperations.Command.DeleteAuthor
{
	public class DeleteAuthorCommand
	{
        public int AuthorId { get; set; }

        private readonly BookStoreDbContext _dbContext;

		public DeleteAuthorCommand(BookStoreDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Handle()
		{
			var command = _dbContext.Authors.FirstOrDefault(x=>x.Id == AuthorId);
			if (command == null) 
			{
				throw new InvalidOperationException("Yazar Bulunamadı");
			}
			if(_dbContext.Books.Any(x => x.AuthorId == AuthorId)) 
			{
				throw new InvalidOperationException("Yazarın Kayıtlı kitapları olduğu için silinemiyor");
			}
			_dbContext.Remove(command);
			_dbContext.SaveChanges();
		}
	}
}
