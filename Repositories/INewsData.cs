using News.Models;

namespace NewsProject.Repositories
{
	public interface INewsData
	{
		public NewsData GetNewsById(int? id);
		public List<NewsData> GetAllNews();
		public void AddNews(NewsData news);
		public void UpdateNews(NewsData news, int? id);
		public void DeleteNews(int? id);
		public void Save();

	}
}
