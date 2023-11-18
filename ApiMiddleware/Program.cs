using ApiMiddleware.Entity;
using MediumClient.Services;
using System.Net.Http.Headers;

namespace ApiMiddleware
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ContentContext>();
            builder.Services.AddHttpClient("MediumApiClient", client =>
            {
                client.BaseAddress = new Uri("https://api.medium.com/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Accept-Charset", "utf-8");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "181d415f34379af07b2c11d144dfbe35d");
                // Other HttpClient configurations if required
            });
            builder.Services.AddSingleton<IMediumService, MediumService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}