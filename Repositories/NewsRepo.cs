using NewsProject.Models;
using NewsData = News.Models.NewsData;

namespace NewsProject.Repositories
{
	public class NewsRepo:INewsData
	{
		private readonly NewsDBContext context;
		public NewsRepo(NewsDBContext _context)
		{
			context = _context;
		}
		public NewsData GetNewsById(int? id)
		{
			var newsData = context.news.FirstOrDefault(a => a.Id == id);
			return newsData;
		}
		public List<NewsData> GetAllNews()
		{
			return context.news.ToList();
		}
		public void AddNews(NewsData newf)
		{
			context.news.Add(newf);
		}
		public void UpdateNews(NewsData news, int? id)
		{
			var oldNews = context.news.FirstOrDefault(a => a.Id == id);
			if (oldNews != null)
			{
				oldNews.Title = news.Title;
				oldNews.Publication = news.Publication;
				oldNews.NewsDescription = news.NewsDescription;
				oldNews.Creation = news.Creation;
				oldNews.Author.Name= news.Author.Name;
			}
		}
		public void DeleteNews(int? id)
		{
			var news = context.news.FirstOrDefault(a => a.Id == id);
			context.news.Remove(news);
		}
		public void Save()
		{
			context.SaveChanges();
		}
	}
}
