using MvcDemoPractice.Models;

namespace MvcDemoPractice.Repository
{
    public interface Ilogin
    {
        LoginRepo Add(LoginRepo login);
        LoginRepo update(LoginRepo login);

        LoginRepo Get(String Name);

        IEnumerable<LoginRepo> GetAll();
        LoginRepo delete(string name);

        public record Hug(string Name);
    }
}
