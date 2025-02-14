using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6Ass.Models;

namespace Mission6Ass.Controllers;

public class HomeController : Controller
{

    private MovieFormContext _context; 
    
    public HomeController(MovieFormContext context) // constructor
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult KnowJoel()
    {
        return View();
    }

    [HttpGet]
    public IActionResult MovieForm()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult MovieForm(MovieForm response)
    {
        _context.MovieForms.Add(response); // add response to database
        _context.SaveChanges(); // save the changes
        
        return RedirectToAction("MovieForm"); // reload page so form is empty
    }
}