using News.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace News
{
	public class NewsData
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string NewsDescription { get; set; }
		public DateOnly Publication {  get; set; }
		public DateTime Creation { get; set; }
		//author
		public virtual Authors authors { get; set; }
		[ForeignKey("Authors")]
		public int AuthId { get; set; }	
	}
}
