using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Justus.Models;

namespace Mission06_Justus.Controllers;

public class HomeController : Controller
{
    //Create instance of Database usable throughout the file
    private MovieEntryContext _context;

    public HomeController(MovieEntryContext temp)
    {
        _context = temp;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnow()
    {
        return View();
    }

    [HttpGet]
    public IActionResult EnterMovies()
    {
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        return View("EnterMovies", new Movie());
    }

    [HttpPost]
    // Add movie to database when submitted and show confirmation page. 
    public IActionResult EnterMovies(Movie entry)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(entry);
            _context.SaveChanges();

            return View("Confirmation", entry);
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View(entry);
        }
    }
    
    //Table with all the movies in the database
    public IActionResult MovieCollection()
    {
        var entries = _context.Movies
            .Include(x => x.Category)
            .OrderBy(x => x.Title).ToList();

        return View(entries);
    }

    //Brings user to add movie form but populates with the data from the movie they want to edit
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movieToEdit = _context.Movies
            .Single(x => x.MovieId == id);

        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();

        return View("EnterMovies", movieToEdit);
    }

    //Update Database
    [HttpPost]
    public IActionResult Edit(Movie updatedInfo)
    {
        _context.Update(updatedInfo);
        _context.SaveChanges();

        return RedirectToAction("MovieCollection");
    }

    //Delete confirmation page
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var movieToDelete = _context.Movies
            .Single(x => x.MovieId == id);

        return View(movieToDelete);
    }

    //Delete record from database
    [HttpPost]
    public IActionResult Delete(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();

        return RedirectToAction("MovieCollection");
    }
}