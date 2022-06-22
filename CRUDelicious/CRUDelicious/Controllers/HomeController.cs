using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
//using Dish.Models;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

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

    [HttpGet("Home")]
    public IActionResult Home()
    {
        ViewBag.AllDishes = _context.Dishes.OrderBy(d => d.CreatedAt).ToList();
        return View();
    }

    [HttpGet("New")]
    public IActionResult New()
    {
        return View();
    }

    [HttpPost("new/dish")]
    public IActionResult procNewDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Home");
        }
        else
        {
            //
            return View("New");
        }
    }

    [HttpGet("Dish/{id}")]
    public IActionResult Dish(int id)
    {
        ViewBag.SingleDish = _context.Dishes.FirstOrDefault(w => w.Dishid == id);
        
        return View("Dish");
    }

    // Inside HomeController
    [HttpGet("delete/{Id}")]
    public IActionResult DeleteDish(int Id)
    {
        // Like Update, we will need to query for a single user from our Context object
        Dish sDish = _context.Dishes.SingleOrDefault(s => s.Dishid == Id);

        // Then pass the object we queried for to .Remove() on Users
        _context.Dishes.Remove(sDish);

        // Finally, .SaveChanges() will remove the corresponding row representing this User from DB 
        _context.SaveChanges();
        // Other code
        return RedirectToAction("Home");
    }

    //[HttpGet("UpdateForm/{id}")]
    //public IActionResult UpdateFrom(int id)
    //{
    //    ViewBag.uDish = _context.Dishes.FirstOrDefault(a => a.Dishid == id);
    //    return View("UpdateForm");
    //}

    [HttpGet("UpdateForm/{id}")]
    public IActionResult UpdateForm(int id)
    {
        Dish RetrievedDish = _context.Dishes.FirstOrDefault(u => u.Dishid == id);

        return View(RetrievedDish);
    }


    [HttpPost("update/{id}")]
    public IActionResult ProcDishUpdate(int id, Dish updatedDish)
    {
        //if(ModelState.IsValid)
        //{
            Dish RetrievedDish = _context.Dishes.FirstOrDefault(u => u.Dishid == id);
            
            RetrievedDish.Name = updatedDish.Name;
            RetrievedDish.Chef = updatedDish.Chef;
            RetrievedDish.Tastiness = updatedDish.Tastiness;
            RetrievedDish.Calories = updatedDish.Calories;
            RetrievedDish.Description = updatedDish.Description;
            RetrievedDish.UpdatedAt = DateTime.Now;
            

            
            _context.SaveChanges();

            return RedirectToAction("Home");
        //}
        //else
        //{
        //    return View("UpdateForm/id");
        //}
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

