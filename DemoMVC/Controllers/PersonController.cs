using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;
using DemoMVC.Data;
using Microsoft.EntityFrameworkCore;
namespace DemoMVC.Controllers;
using DemoMVC.AutoId;

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
    Person person = new Person();
    string LastId= _context.Person.Max(e => e.Id);
      var nextID = DemoMVC.AutoId.Create.GetNextId(LastId);

    ViewBag.NextId = nextID;
    return View();
}

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FullName,Address,Email")] Person person)
    {
        if (ModelState.IsValid)
        {   if(!string.IsNullOrEmpty(person.Id))
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
        var entity = _context.Person.Find(id);
        return View(entity);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update([Bind("Id,FullName,Address,Email")] Person person)
    {

        if (ModelState.IsValid)
        {
            _context.Update(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(person);

    }
    public IActionResult Upload()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upload(IFormFile File)
    {
        if (File != null && File.Length > 0)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "SaveUpload");
            var filePath = Path.Combine(path, File.FileName);

            // Lưu file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                File.CopyTo(stream);
            }
        }
        else
        {
            ModelState.AddModelError("", "Vui lòng chọn một tệp để tải lên.");
        }


        return View();
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
