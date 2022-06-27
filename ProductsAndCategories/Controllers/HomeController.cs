using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;

namespace ProductsAndCategories.Controllers;

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

    [HttpGet("products")]
    public IActionResult NewProductForm()
    {
        ViewBag.products = _context.Products.ToList();
        return View("newProductForm");
    }

    [HttpGet("category")]
    public IActionResult NewCategoryForm()
    {
        ViewBag.categories = _context.Categories.ToList();
        return View();
    }

    [HttpPost("products/new")]
    public IActionResult newProductProc(Product product)
    {
        if(ModelState.IsValid)
        {
            _context.Add(product);
            // OR _context.Users.Add(newUser);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("NewProductForm");
        }
    }

    [HttpPost("category/new")]
    public IActionResult newCategoryProc(Category category)
    {
        if(ModelState.IsValid)
        {
            _context.Add(category);
            // OR _context.Users.Add(newUser);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("NewCategoryForm");
        }
    }

    [HttpGet("category/{id}")]
    public IActionResult CategoryAssociation(int id)
    {
        //ViewBag.SingleCategory = _context.Categories.Include(s => s.Products)
        //    .ThenInclude(s => s.Category)
        //    .FirstOrDefault(s => s.CategoryID == id);
        // ?? 
        ViewBag.SingleCategory = _context.Categories.Include(s=> s.Products).ThenInclude(s => s.Product).FirstOrDefault(s => s.CategoryID == id);


        // Same as Product 
        ViewBag.NegProducts = _context.Products
        .Include(p => p.Categories)
        .ThenInclude(c => c.Category)
        .Where(p => !(p.Categories.Any(c => c.CategoryID == id)));

        return View();

    }

    [HttpGet("Product/{id}")]
    public IActionResult ProductAssociation(int id)
    {
        ViewBag.SingleP = _context.Products
    .Include(P => P.Categories)
    .ThenInclude(C => C.Category)
    .FirstOrDefault(p => p.ProductID == id);
        

        ViewBag.NegCategories = _context.Categories
        .Include(C => C.Products)
        .ThenInclude(P => P.Product)
        .Where(c => !(c.Products.Any(p =>  p.ProductID == id)) );

        return View();
    }

    // Association Posts
    [HttpPost("CategoryProcAssociation")]
    public IActionResult CategoryProcAssociation(Association i)
    {
        if (ModelState.IsValid)
        {
            _context.Add(i);
            // OR _context.Users.Add(newUser);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("NewCategoryForm");
        }
    }

    [HttpPost("ProductProcAssociation")]
    public IActionResult ProductProcAssociation(Association i)
    {
        if (ModelState.IsValid)
        {
            _context.Add(i);
            // OR _context.Users.Add(newUser);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("NewCategoryForm");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
