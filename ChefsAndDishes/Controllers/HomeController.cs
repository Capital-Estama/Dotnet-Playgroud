using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsAndDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsAndDishes.Controllers;

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
        // Refresh Get all Chefs
        List<Chef> ChefsWithDishes = _context.Chefs.Include(chef => chef.Dishes)
        .ToList();
        
        return View(ChefsWithDishes);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet("Dishes")]
    public IActionResult Dishes()
    {
        // Get all Dishes with ChefID Join
        List<Dish> dishes = _context.Dishes.Include(dish => dish.Chef).ToList();

        return View(dishes);
    }

    [HttpGet("new")]
    public IActionResult AddChef()
    {
        return View("AddChef");
    }

    [HttpPost("newChefProc")]
    public IActionResult newChefProc(Chef newChef)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newChef);
            // OR _context.Users.Add(newUser);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("AddChef");
        }
    }

    [HttpGet("Dishes/new")]
    public IActionResult AddDish()
    {
        // Get all Chefs
        ViewBag.chefs = _context.Chefs.ToList();
        return View("AddDish");
    }

    [HttpPost("newDishProc")]
    public IActionResult newDishProc(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            // OR _context.Users.Add(newUser);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("AddDish");
        }
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
