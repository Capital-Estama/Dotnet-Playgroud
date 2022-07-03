using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers;

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

    [HttpPost("register")]
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
            var userDbcontext = _context.Users.FirstOrDefault(s => s.Email == user.Email);
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetInt32("UserId", userDbcontext.UserID);
            return RedirectToAction("Dashboard");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpPost("login")]
    public IActionResult Login(LogUser loginUser)
    {
        if (ModelState.IsValid)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.Email == loginUser.LogEmail);
            // If no user exists with provided email
            if (userInDb == null)
            {
                // Add an error to ModelState and return to View!
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("Index");
            }
            // Initialize hasher object
            var hasher = new PasswordHasher<LogUser>();

            // verify provided password against hash stored in db
            var result = hasher.VerifyHashedPassword(loginUser, userInDb.Password, loginUser.LogPassword);

            // result can be compared to 0 for failure
            if (result == 0)
            {
                // handle failure (this should be similar to how "existing email" is handled)
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("Index");
            }
            // Mod this to store UserID
            HttpContext.Session.SetString("UserEmail", loginUser.LogEmail);
            var userDbcontext = _context.Users.FirstOrDefault(s => s.Email == loginUser.LogEmail);
            HttpContext.Session.SetString("UserEmail", loginUser.LogEmail);
            // Save userID to session
            HttpContext.Session.SetInt32("UserId", userDbcontext.UserID);
            return RedirectToAction("Dashboard");
        }
        else
        {   
            return View("Index");
        }
    }

    [HttpGet("Dashboard")]
    public IActionResult Dashboard()
    {
        if(HttpContext.Session.GetString("UserEmail") == null)
        {
            RedirectToAction("Register");
        }

        //List<Wedding> Weddings
        //ViewBag.AllWeddings
        List<Wedding> Weddings = _context.Weddings
        .Include(s => s.Guests)
        .ThenInclude(guest => guest.User)
        .ToList();

        int? temp = HttpContext.Session.GetInt32("UserId");
        ViewBag.CreatorID = temp;

        return View(Weddings);
    }

    [HttpGet("wedding/{id}")]
    public IActionResult OneWedding(int id)
    {
        Wedding oneWed = _context.Weddings
        .Include(s => s.Guests)
        .ThenInclude(s => s.User)
        .FirstOrDefault(s => s.WeddingID == id);
        

        return View("OneWedding", oneWed);
    }


    [HttpGet("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();

        return RedirectToAction("Index");
    }

    //######################################################################
    //# CRUD on Many to Many
    //#
    //#
    //# ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ 
    //######################################################################


    [HttpGet("RSVP/{WeddingID}")]
    public IActionResult RSVP(int WeddingID)
    {
        Association RSVP = new Association();
        // Todo: check (cast to int?)
        RSVP.UserID = HttpContext.Session.GetInt32("UserId");
        RSVP.WeddingID = WeddingID;

        // add Guest to Wedding 
        _context.Associations.Add(RSVP);
        _context.SaveChanges();

        return RedirectToAction("Dashboard");
    }

    [HttpGet("UnRSVP/{WeddingID}")]
    public IActionResult UnRSVP(int WeddingID)
    {
        // Then pass the object we queried for to .Remove() on Users
        // _context.Users.Remove(RetrievedUser);
        Association DelRSVP = _context.Associations
        .Where(s => s.WeddingID == WeddingID)
        .FirstOrDefault(s => s.UserID == HttpContext.Session.GetInt32("UserId"));
        _context.Remove(DelRSVP);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    // todo: get ID from session & add check for correct logged in user
    [HttpGet("Create/newWedding")]
    public IActionResult CreateNewWedding()
    {

        return View("newWedding");
    }

    [HttpGet("delete/wedding/{id}")]
    public IActionResult DelWedding(int id)
    {
        // todo: add check if logUser clicked Link
        if (HttpContext.Session.GetString("UserEmail") == null)
        {
            RedirectToAction("dashboard");
        }

        Wedding removeWed = _context.Weddings.FirstOrDefault(s => s.WeddingID == id);
        _context.Remove(removeWed);
        _context.SaveChanges();
        return RedirectToAction("dashboard");
    }

    [HttpPost("Create/wedding")]
    public IActionResult AddWedding(Wedding newWedding)
    {
        if(ModelState.IsValid)
        {
            _context.Weddings.Add(newWedding);
            _context.SaveChanges();
            // change to Dashboard -- return RedirectToAction($"wedding/{newWedding.WeddingID}");
            return RedirectToAction("dashboard");
        }
        else
        {
            return View("newWedding");
        }

    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
