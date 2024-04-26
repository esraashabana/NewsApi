
using System.ComponentModel.DataAnnotations.Schema;

namespace News.Models
{
	public class Authors
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Bio {  get; set; }	
		public int Age { get; set; }
		public string Email { get; set; }
		public virtual List<NewsData> AuthorNews { get; set; } = new List<NewsData>();

	}
}
