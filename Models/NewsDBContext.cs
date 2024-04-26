using Microsoft.EntityFrameworkCore;
using News;
using News.Models;

namespace NewsProject.Models
{
	public class NewsDBContext:DbContext
	{
		public NewsDBContext() { }
		public DbSet<Authors> authors { get; set; }
		public DbSet<NewsData> news { get; set; }	
		public NewsDBContext(DbContextOptions options) : base(options)
		{

		}





	}
}
