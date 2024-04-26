
using News.Models;
using NewsProject.Models;

namespace NewsProject.Repositories
{
	public class AuthorsRepo:IAuthors
	{
		private readonly NewsDBContext context;
		public AuthorsRepo(NewsDBContext _context)
		{
			context = _context;
		}
		public Authors GetAuthorById(int? id)
		{
			var author = context.authors.FirstOrDefault(a => a.Id == id);
			return author;
		}
		public List<Authors> GetAllAuthors()
		{
			return context.authors.ToList();
		}
		public void AddAuthors(Authors authors)
		{
			context.authors.Add(authors);
		}
		public void UpdateAuthor(Authors authors, int? id)
		{
			var oldAuthor = context.authors.FirstOrDefault(a => a.Id == id);
			if (oldAuthor != null)
			{
				oldAuthor.Age = authors.Age;
				oldAuthor.Name = authors.Name;
				oldAuthor.Email = authors.Email;
				oldAuthor.Bio = authors.Bio;
			}
		}
		public void DeleteAuthor(int? id)
		{
			var author = context.authors.FirstOrDefault(a=>a.Id==id);
			context.authors.Remove(author);
		}
		public void Save()
		{
			context.SaveChanges();
		}
	}
}
