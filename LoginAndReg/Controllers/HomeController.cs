using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using LoginAndReg.Models;

namespace LoginAndReg.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet("Login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost("Register")]
    public IActionResult Register(User user)
    {
        if(ModelState.IsValid)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                // Manually add a ModelState error to the Email field, with provided
                // error message
                ModelState.AddModelError("Email", "Email already in use!");
                Console.WriteLine("Email Hit!!_____________________________!!!");

                // You may consider returning to the View at this point
                return View("Index");
            }

            // Initializing a PasswordHasher object, providing our User class as its type
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            user.Password = Hasher.HashPassword(user, user.Password);
            //Save your user object to the database

            _context.Add(user);
            _context.SaveChanges();
            HttpContext.Session.SetString("UserEmail", user.Email);
            return RedirectToAction("Success");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet("Success")]
    public IActionResult Success()
    {
        if(HttpContext.Session.GetString("UserEmail") != null)
        {
            return View();
        }
        else
        {
            return RedirectToAction("Index");
        }
        
    }

    [HttpPost("login/u")]
    public IActionResult loginCheck(LogUser loginUser)
    {
        if(ModelState.IsValid)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.Email == loginUser.Email);
            // If no user exists with provided email
            if (userInDb == null)
            {
                // Add an error to ModelState and return to View!
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("SomeView");
            }
            // Initialize hasher object
            var hasher = new PasswordHasher<LogUser>();

            // verify provided password against hash stored in db
            var result = hasher.VerifyHashedPassword(loginUser, userInDb.Password, loginUser.Password);

            // result can be compared to 0 for failure
            if (result == 0)
            {
                // handle failure (this should be similar to how "existing email" is handled)
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("Login");
            }
            // Mod this to store UserID
            HttpContext.Session.SetString("UserEmail", loginUser.Email);
            return RedirectToAction("Success");
        }
        else
        {
            return View("Login");
        }
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();

        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
