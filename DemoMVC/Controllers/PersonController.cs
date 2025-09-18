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
        {   if(person.Id != 0)
            {
                 var existingPerson = await _context.Person.FirstOrDefaultAsync(p => p.Id == person.Id);

                  if (existingPerson != null)
                  {
                    // Xóa bản ghi cũ (có Id trùng)
                    _context.Person.Remove(existingPerson);
                    await _context.SaveChangesAsync();
                  }
            }
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
    public async Task<IActionResult> Delete([Bind("Id")] Person person)
    {
        if (ModelState.IsValid)
        {
            var personInDb = await _context.Person.FindAsync(person.Id);
            if (personInDb == null)
            {
                return NotFound();
            }

            _context.Person.Remove(personInDb);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        return View(person);
    }

 


    [HttpGet]
    public IActionResult Update(string id)
    {
        int number = int.Parse(id);
        var entity = _context.Person.Find(number);
        return View(entity);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update([Bind("Id,FullName,Address")] Person person)
    {
       
        if (ModelState.IsValid)
        {
            _context.Update(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(person);
        
    }


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
