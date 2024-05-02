
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("CorsAllowed",
				builder =>
				{
					builder.AllowAnyOrigin();
					builder.AllowAnyMethod();
					builder.AllowAnyHeader();
				});
			});
			builder.Services.AddAuthentication(option => option.DefaultAuthenticateScheme = "myscheme")
			   .AddJwtBearer("myscheme",
			   op =>
			   {
				   #region secret key
				   string key = "This is my secret keyyyyyyyyyyyyyyy";
				   var secertkey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(key));
				   #endregion
				   op.TokenValidationParameters = new TokenValidationParameters()
				   {
					   IssuerSigningKey = secertkey,
					   ValidateIssuer = false,
					   ValidateAudience = false

				   };
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
			app.UseCors("CorsAllowed");
			app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseAuthorization();
			app.MapControllers();
			app.Run();
		}
	}
}
