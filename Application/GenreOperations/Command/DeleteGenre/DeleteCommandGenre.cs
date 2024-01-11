using WebApi.DbOperation;

namespace WebApi.Application.GenreOperations.Command.DeleteGenre
{
	public class DeleteCommandGenre
	{
        public int Id { get; set; }
        private readonly BookStoreDbContext _dbContext;

		public DeleteCommandGenre(BookStoreDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Handle() 
		{
			var genre = _dbContext.Genres.FirstOrDefault(x=>x.Id == Id);
			if (genre == null)
			{
				throw new InvalidOperationException("Kitap türü bulunamadı");
			}
			_dbContext.Genres.Remove(genre);
			_dbContext.SaveChanges();
		}
	}
}
