using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;
using DemoMVC.Data;
using Microsoft.EntityFrameworkCore;
namespace DemoMVC.Controllers;


public class PersonController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<PersonController> _logger;

    public PersonController(ILogger<PersonController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

  
public async Task<IActionResult> Index()
{
    var model = await _context.Person.ToListAsync();
    return View(model);
}

[HttpGet]
public IActionResult Create()
{
    return View();
}

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FullName,Address")] Person person)
    {
        if (ModelState.IsValid)
        {
            _context.Add(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(person);
    }

    [HttpGet]
    public IActionResult Delete()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete([Bind("Id,FullName,Address")] Person person)
    {
        if (ModelState.IsValid)
        {
            _context.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(person);
    }
/*
    {
        if (id == null || _context.Person == null)
        {
            return NotFound();
        }

        var person = await _context.Person
            .FirstOrDefaultAsync(m => m.Id == id);
        if (person == null)
        {
            return NotFound();
        }

        _context.Person.Remove(person);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
*/


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
