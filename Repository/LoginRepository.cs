using Microsoft.AspNetCore.Identity;
using MvcDemoPractice.Context;
using MvcDemoPractice.Models;

namespace MvcDemoPractice.Repository
{
    public class LoginRepository : Ilogin
    {
        private List<LoginRepo> login;
        private readonly LoginDbContext context;
        public LoginRepository(LoginDbContext loginDbContext)
        {
            context = loginDbContext;
            //login = new List<LoginRepo>()
            //{
            //     new LoginRepo{Name="Tejaswini",Password="12345"},
            //     new LoginRepo{Name="Swathi",Password="123"},
            //};
        }
        public LoginRepo Add(LoginRepo login)
        {
            context.logins.Add(login);
            context.SaveChanges();
            return login;
        }

        public LoginRepo delete(string Name)
        {
            LoginRepo login = context.logins.Find(Name);
            if(login != null)
            {
                context.logins.Remove(login);
                context.SaveChanges();
            }
            return login;
        }

        public LoginRepo Get(string Name)
        {
            return context.logins.Find(Name);
        }

        public IEnumerable<LoginRepo> GetAll()
        {
            return context.logins;
        }

        public LoginRepo update(LoginRepo modifiedlogin)
        {
            context.Update(modifiedlogin);
            context.SaveChanges();
            return modifiedlogin;
        }
    }
}
