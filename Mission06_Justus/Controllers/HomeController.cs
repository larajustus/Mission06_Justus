using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
        return View();
    }

    [HttpPost]
    // Add movie to database when submitted and refresh page. 
    public IActionResult EnterMovies(Movie entry)
    {
        _context.Movies.Add(entry);
        _context.SaveChanges();
        return RedirectToAction("EnterMovies");
    }
}