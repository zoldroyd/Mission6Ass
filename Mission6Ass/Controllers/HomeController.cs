using System.Diagnostics;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        ViewBag.Categories = _context.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();
        
        return View("MovieForm", new MovieForm());
    }

    [HttpPost]
    public IActionResult MovieForm(MovieForm response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response); // add response to database
            _context.SaveChanges(); // save the changes

            return RedirectToAction("MovieForm"); // reload page so form is empty
        }
        else
        {
            // add view bag so its loads the data
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();
            
            return View(response);
        }
    }

    public IActionResult MovieList()
    {
        var movies = _context.Movies
            .Include(x => x.Category) // join the category names
            .OrderBy(x => x.Title)
            .ToList();
        
        return View(movies);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        // get specific record by id
        var recordToEdit = _context.Movies
            .Single(x => x.MovieId == id);
        
        // viewbag to load data
        ViewBag.Categories = _context.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();
        
        return View("MovieForm", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(MovieForm updatedInfo)
    {
        if (ModelState.IsValid)
        {
            _context.Update(updatedInfo);  // Update the movie record
            _context.SaveChanges();  // Save changes to the database
        
            return RedirectToAction("MovieList");  // Redirect to movie list page
        }

        // If model state is invalid, reload the categories and return the form
        ViewBag.Categories = _context.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();
    
        return View("MovieForm", updatedInfo);
    }


    [HttpGet]
    public IActionResult Delete(int id)
    {
        // get specific record by id
        var recordToDelete = _context.Movies
            .Single(x => x.MovieId == id);
        
        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(MovieForm form)
    {
        _context.Movies.Remove(form);
        _context.SaveChanges();
        
        return RedirectToAction("Movielist");
    }
}