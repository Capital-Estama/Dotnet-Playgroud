using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyValidations.Models;
//add namespace
using DojoSurvey.Models;

namespace DojoSurveyValidations.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("proccess")]
    public IActionResult proccess(User user)
    {
        if(ModelState.IsValid)
        {
            Console.WriteLine($"isVaild {DateTime.Now}");
           return RedirectToAction("Success" , user);
        }
        else
        {
            Console.WriteLine("Notvalid");
            return View("Index");
        }
        
    }
    [HttpGet("Success")]
    public IActionResult Success(User user)
    {

        return View(user);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
