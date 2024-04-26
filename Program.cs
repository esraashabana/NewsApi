
using Microsoft.EntityFrameworkCore;
using NewsProject.Models;
using NewsProject.Repositories;

namespace News
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<NewsDBContext>(options =>
			{
				options.UseLazyLoadingProxies().UseSqlServer("Server=.;Database = NewsDB; Integrated Security = True; TrustServerCertificate = True; ");
			});
			builder.Services.AddScoped<IAuthors, AuthorsRepo>();
			builder.Services.AddScoped<INewsData, NewsRepo>();
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
