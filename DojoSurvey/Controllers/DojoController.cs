using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey.Controllers;

public class DojoController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpPost("process")]
    public IActionResult process(string Name, string DojoLocation, string FavLang, string Comments)
    {
        ViewBag.Name = Name;
        ViewBag.DojoLocation = DojoLocation;
        ViewBag.Lang = FavLang;
        ViewBag.Comments = Comments; 

        return View("Success");
    }

    // [HttpGet("success")]
    // public IActionResult Success(string Name, string DojoLocation, string FavLang, string Comments)
    // {
    //     return View(Success);
    // }
}