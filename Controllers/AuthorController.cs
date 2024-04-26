using Azure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using News.Models;
using NewsProject.Repositories;

namespace NewsProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorController : ControllerBase
	{
		private readonly IAuthors repo;
		public AuthorController(IAuthors _repo)
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
			var result = repo.GetAuthorById(id);
			return Ok(result);
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			var result = repo.GetAllAuthors();
			return Ok(result);
		}
		[HttpPost]
		public IActionResult Add(Authors author)
		{
			if (author == null)
			{
				return BadRequest();
			}
			if (ModelState.IsValid)
			{
				repo.AddAuthors(author);
				repo.Save();
				return Ok();	
			}
			return BadRequest(ModelState);
		}
		[HttpPut]
		public IActionResult Update(Authors author,int? id)
		{
          if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

		}

	}
}
