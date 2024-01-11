using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperation
{
	public class DataGenerator
	{
		public static void Initilize(IServiceProvider serviceProvider)
		{
			using(var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
			{
				if (context.Books.Any())
				{
					return;
				}
				context.Authors.AddRange(
					new Author
					{
						Name = "Adam",
						LastName ="Smith",
						DateOfBirth = new DateTime(2001, 06, 12),
					},
					new Author
					{
						Name = "Victor",
						LastName = "Hugo",
						DateOfBirth = new DateTime(1976, 03, 04),
					},
					new Author
					{
						Name = "Jack",
						LastName = "London",
						DateOfBirth = new DateTime(1985, 09, 22),
					}
				);

				context.Genres.AddRange(
					new Genre
					{
						Name = "Personel Growth"
					},
					new Genre
					{
						Name = "Science Fiction"
					},
					new Genre
					{
						Name = "Romance"
					}
				);

				context.Books.AddRange
				(
					new Book()
					{
						Title = "LeanStartup",
						GenreId = 1, // Personel Growth	
						PageCount = 200,
						AuthorId = 1,
						PublisDate = new DateTime(2001, 06, 12),
					},
					new Book()
					{
						Title = "Herland",
						GenreId = 2, // Science Fiction	
						PageCount = 250,
						AuthorId = 2,
						PublisDate = new DateTime(2010, 05, 23),
					},
					new Book()
					{
						Title = "Dune",
						GenreId = 2, // Personel Growth	
						PageCount = 540,
						AuthorId = 1,
						PublisDate = new DateTime(2002, 05, 22),
					}
				);

				context.SaveChanges();
			}
		}
	}
}
