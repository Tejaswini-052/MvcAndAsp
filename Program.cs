using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MvcDemoPractice.Context;
using MvcDemoPractice.Controllers;
using MvcDemoPractice.Models;
using MvcDemoPractice.Repository;

namespace MvcDemoPractice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var Connection = builder.Configuration.GetConnectionString("LoginDbContext");

        // Add services to the container.
        builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<Ilogin, LoginRepository>();

            builder.Services.AddDbContext<LoginDbContext>(options => options.UseSqlServer(Connection));
          
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.MapGet("/", () => "Welcome to login page");

            app.MapGet("/", (
    [FromServices] Ilogin repository) =>
            {
                return repository.GetAll();
            });

    //        app.MapDelete("/", (
    //[FromServices] Ilogin repository) =>
    //        {
    //            return repository.delete("Shalini");
    //        });

            //    app.MapPost("/", (IFormFile file,
            //[FromServices] Login repository) =>
            //        {
            //            using var reader = new StreamReader(file.OpenReadStream());

            //            while (reader.Peek() >= 0)
            //                repository.LoginForm();

            //        });

          //  app.MapPost("/home", () => "Welcome to home page by Post");
          // app.MapPut("/login", () => "Welcome to login page by Put");



            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
         
        }
    }
}