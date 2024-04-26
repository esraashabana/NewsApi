using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News.Models;
using NewsProject.DTO;
using NewsProject.Repositories;

namespace NewsProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NewsController : ControllerBase
	{
		private readonly INewsData repo;
		public NewsController(INewsData _repo)
		{
			repo = _repo;
		}
		[HttpGet("{id:int}")]
		public IActionResult GetById(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var result = repo.GetNewsById(id);
			NewsDTO newsDTO = new NewsDTO();
			newsDTO.Id = result.Id;
			newsDTO.Title=result.Title;
			newsDTO.Publication=result.Publication;
			newsDTO.AuthorName = result.Author.Name;
			newsDTO.Publication=result.Publication;
			newsDTO.Creation=result.Creation;
			return Ok(newsDTO);
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			var result = repo.GetAllNews();
			var dto=new List<NewsDTO>();	
			foreach(var item in result)
			{
				NewsDTO newsDTO=new NewsDTO();
				newsDTO.Id = item.Id;
				newsDTO.Title = item?.Title;
				newsDTO.Publication = item?.Publication;
				newsDTO.AuthorName = item?.Author.Name;
				newsDTO.Publication = item?.Publication;
				newsDTO.Creation = item.Creation;
				dto.Add(newsDTO);
			}
			return Ok(dto);
		}
		[HttpPost]
		public IActionResult Add(NewsData news)
		{
			if (news == null)
			{
				return BadRequest();
			}
			if (ModelState.IsValid)
			{
				repo.AddNews(news);
				repo.Save();
				return Ok();
			}
			return BadRequest(ModelState);
		}
		[HttpPut]
		public IActionResult Update(NewsData news, int? id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			repo.UpdateNews(news, id);
			repo.Save();
			return Ok();
		}
		[HttpDelete]
		public IActionResult Delete(int id)
		{
			repo?.DeleteNews(id);
			repo?.Save();
			return Ok();
		}

	}
}

