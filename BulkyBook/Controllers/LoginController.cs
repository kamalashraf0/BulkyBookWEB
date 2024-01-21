using BulkyBook.Models;
using BulkyBookWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Diagnostics;

namespace BulkyBook.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDBContext _dbContext;



        public LoginController(ApplicationDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        [ActionName("View")]
        public IActionResult Login()
        {
            

            return View();
        }



        [HttpPost]

        public IActionResult Login(LoginViewModel? model)
        {
            if (ModelState.IsValid)
            {
                var login = new LoginViewModel
                {
                    Username = model.Username,
                    Password = model.Password
                };

                _dbContext.Logins.Add(login);
                _dbContext.SaveChanges();
                TempData["Success"] = "Login Successfully";
                return RedirectToAction("Index", "Category"); // Redirect to home page after successful login
            }
            else
            {
                TempData["Error"] = "Invalid login credentials. Please try again.";
            }
            return RedirectToAction("View", "Login");
        }









        //[HttpPost]

        //public IActionResult Login(LoginViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Check if the login credentials are valid (this is just an example, you should implement your authentication logic)
        //        bool isValidCredentials = AuthenticateUser(model.Username, model.Password);

        //        if (isValidCredentials)
        //        {
        //            var login = new LoginViewModel
        //            {
        //                Username = model.Username,
        //                Password = model.Password
        //            };

        //            _dbContext.Logins.Add(login);
        //            _dbContext.SaveChanges();

        //            TempData["Success"] = "Login Successfully";
        //            return RedirectToAction("Index", "Category"); // Redirect to home page after successful login
        //        }
        //        else
        //        {
        //            TempData["Error"] = "Invalid login credentials. Please try again.";
        //        }
        //    }

        //    return RedirectToAction("View" , "Login");
        //}

        //// Example authentication method (replace with your actual authentication logic)
        //private bool AuthenticateUser(string username, string password)
        //{
        //    // Implement your authentication logic here (e.g., check against a user database)
        //    // For demonstration purposes, this is a placeholder and should be replaced with a proper implementation.
        //    return (username == "kaml" && password == "154");
        //}





    }
}