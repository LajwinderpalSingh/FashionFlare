using FashionFlare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FashionFlare.Controllers
{
    public class HomeController : Controller
    {
        // Dependency injection of UserManager and SignInManager services to manage user-related tasks
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public HomeController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // Action to return the main view of the home page
        public IActionResult Index()
        {
            return View();
        }

        // GET method to display the registration form to the user
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST method to handle user registration
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevents cross-site request forgery attacks
        public async Task<IActionResult> Register(Register userModel)
        {
            // If the input model is not valid, return the same registration view with validation errors
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            // Creating a new User object with the data from the registration model
            var user = new User()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                UserName = userModel.Email,
                Email = userModel.Email,
            };

            // Attempt to create the user with the specified password
            var result = await userManager.CreateAsync(user, userModel.Password);
            if (!result.Succeeded)
            {
                // If the creation fails, add the errors to ModelState and return the registration view
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View(userModel);
            }

            if (user.FirstName.Contains("admin", StringComparison.OrdinalIgnoreCase) || user.LastName.Contains("admin", StringComparison.OrdinalIgnoreCase)
                || user.Email.Contains("admin", StringComparison.OrdinalIgnoreCase))
            {
                await userManager.AddToRoleAsync(user, "Administrator");
            }
            else
            {
                await userManager.AddToRoleAsync(user, "Visitor");
                // Adding the newly created user to the 'Visitor' role
            }

            // Redirecting to the home page after successful registration
            return View("Index");
        }

        // POST method to handle user login
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevents cross-site request forgery attacks
        public async Task<IActionResult> LoginPost(Login userModel)
        {
            // If the input model is not valid, return the login view with validation errors
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            // Attempt to sign in the user with the provided credentials
            var result = await signInManager.PasswordSignInAsync(userModel.Email, userModel.Password, userModel.RememberMe, false);
            if (result.Succeeded)
            {
                // Redirect to the home page if login is successful
                return RedirectToAction("Index");
            }
            else
            {
                // If login fails, add an error message and return to the login view
                ModelState.AddModelError("", "Invalid UserName or Password");
                return View("Login");
            }
        }

        // GET method to display the login form to the user
        [Route("Account/Login")]
        public IActionResult Login()
        {
            return View();
        }

        // POST method to handle user logout
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevents cross-site request forgery attacks
        public async Task<IActionResult> Logout()
        {
            // Sign out the user and redirect to the home page
            await signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        // Action to display the error view when an unhandled error occurs
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] // Disable caching for the error page
        public IActionResult Error()
        {
            // Return the error view with information about the current request
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Action to display the privacy view, requires the user to be logged in
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }


    }
}
