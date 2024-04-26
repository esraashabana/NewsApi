using News.Models;

namespace NewsProject.Repositories
{
	public interface IAuthors
	{
		public Authors GetAuthorById(int? id);
		public List<Authors> GetAllAuthors();
		public void AddAuthors(Authors authors);
		public void UpdateAuthor(Authors authors, int? id);
		public void DeleteAuthor(int? id);
		public void Save();
	}
}
