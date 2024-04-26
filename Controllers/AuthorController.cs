using Azure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using News.Models;
using NewsProject.DTO;
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
			AuthorDto authorDto=new AuthorDto();
			var result = repo.GetAuthorById(id);
			authorDto.Id=result.Id;
			authorDto.Name=result.Name;
			authorDto.Age=result.Age;
			authorDto.Email=result.Email;
			authorDto.Bio=result.Bio;
			return Ok(authorDto);
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			var result = repo.GetAllAuthors();
			var ListOfDtos = new List<AuthorDto>();
			foreach (var authorDto in result)
			{
				AuthorDto author = new AuthorDto();
				author.Id = authorDto.Id;
				author.Name = authorDto?.Name;
				author.Age = authorDto.Age;
				authorDto.Email = authorDto?.Email;
				authorDto.Bio = authorDto?.Bio;
				ListOfDtos.Add(author);
			}
			return Ok(ListOfDtos);
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
		public IActionResult Update(Authors author, int? id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			repo.UpdateAuthor(author, id);
			repo.Save();
			return Ok();
		}
		[HttpDelete]
		public IActionResult Delete(int id)
		{
			repo?.DeleteAuthor(id);
			repo?.Save();
			return Ok();
		}

	}
}
