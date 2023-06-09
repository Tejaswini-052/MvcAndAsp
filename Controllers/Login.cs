using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MvcDemoPractice.Models;
using MvcDemoPractice.Repository;

namespace MvcDemoPractice.Controllers
{
    public class Login : Controller
    {
        //[ViewData]
        //public string Title{get;set;}

        private readonly Ilogin loginRepository;
       public Login(Ilogin LoginRepository)
        {
            loginRepository = LoginRepository;
        }
       // [Route("AddLogin")]
        [HttpGet]
        public IActionResult LoginForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginForm(LoginRepo login)
        {
            LoginRepo newlogin = loginRepository.Add(login);
            return RedirectToAction("login");
        }

        [HttpGet]
        public IActionResult EditLogin(string Name)
        {
            LoginRepo login = loginRepository.Get(Name);
            return View(login);
        }

        [HttpPost]
        public IActionResult EditLogin(LoginRepo modifiedlogin)
        {
            LoginRepo login = loginRepository.Get(modifiedlogin.Name);
            login.Password = modifiedlogin.Password;
            LoginRepo updatelogin = loginRepository.update(login);
            return RedirectToAction("login");
           
        }

        public IActionResult DeleteLogin(string Name)
        {
            LoginRepo login = loginRepository.delete(Name);
            return RedirectToAction("login");
        }


        public IActionResult login()
        {
            // TempData["Name"] = "Enter name";

            //ViewBag.Log=LoginRepo;


            var logins = loginRepository.GetAll();
            
                
                
            //    new List<LoginRepo>
            //{
            //    new LoginRepo{Name="Tejaswini",Password="12345"},
            //     new LoginRepo{Name="Swathi",Password="123"},
            //};

            
            //ViewData["name"]="Login Creds";
            //ViewData["title"]="Credentials";
            ViewData["logins"] = logins;
            return View(logins);

            //var newLogin = new LoginRepo{

            //Name="Tejaswini",
            //Password="Tej/2002"
            //};
            //return View(newLogin);

            //var activity = new LoginActivity{

            //logins=new newLogin,
            //Activity="Logging in"
            //};
            //return View(activity);
            // string name;
            // if (TempData.ContainsKey("Name"))
            //    name = TempData["Name"].ToString();
            // return View();


            // return View();
        }
	}
}
