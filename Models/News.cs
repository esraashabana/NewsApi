using News.Models;
using NewsProject.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace News.Models
{
	public class NewsData
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string NewsDescription { get; set; }
		public string Publication { get; set; }
		public DateTime Creation { get; set; }
		public virtual Authors Author { get; set; }

		// Foreign key property
		[ForeignKey("Author")]
		public int AuthorId { get; set; }
	}
}
