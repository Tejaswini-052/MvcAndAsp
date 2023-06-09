using DemoWebapi.Data;
using Microsoft.EntityFrameworkCore;

namespace DemoWebapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var Connection = builder.Configuration.GetConnectionString("PassengerDbContext");

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<PassengerDbContext>(options => options.UseSqlServer(Connection));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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