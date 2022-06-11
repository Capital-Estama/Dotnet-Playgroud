using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RandomPasscodeGenerator.Models;

namespace RandomPasscodeGenerator.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // int? test = HttpContext.Session.GetInt32("Counter");
        // Console.WriteLine($"test -----{test}");
        
        if (HttpContext.Session.GetInt32("Counter") == null )
        {
            int counter = 1;
            HttpContext.Session.SetInt32("Counter", counter );

        }

        Console.WriteLine(HttpContext.Session.GetInt32("Counter"));
        // HttpContext.Session.SetString("Passcode","");
        List<string> Key = new List<string>() {"A" ,"B" ,"C", "D", "E","F", "1","2", "3","4","5","6","7","8","9"};
        Random rnd = new Random();
        string? Passcode = "" ;
        for(int i = 0; i < 14; i++)
        {
            Passcode += Key[rnd.Next(0,Key.Count)];

        }
        ViewBag.passcode = Passcode;

        return View();
    }

    [HttpGet("Generate")]
    public IActionResult Generate()
    {
        int c = (int)HttpContext.Session.GetInt32("Counter");
        c += 1;
        Console.WriteLine($"Generate Vale {c}");
        HttpContext.Session.SetInt32("Counter", c );
        c = (int)HttpContext.Session.GetInt32("Counter");
        Console.WriteLine($"after update {c}");
        // c += 1;
        // HttpContext.Session.SetInt32("Counter", (int?)c;
        return RedirectToAction("Index" );
    }

    [HttpGet("Clear")]
    public IActionResult Clear()
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
