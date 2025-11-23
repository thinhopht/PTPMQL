using System;
using X.PagedList;
using X.PagedList.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoMVC.Data;
using DemoMVC.Models;
using DemoMVC.AutoId;
namespace DemoMVC.Controllers

{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index(int ? page)
        {

            var model = _context.Employee.OrderBy(e => e.EmployeeId);
            return View(model.ToPagedList(page ?? 1, 5));
        }
        [HttpPost]
        public async Task<IActionResult> Index(string AgeFilter)
        {
            List<Employee> employees;
            if (string.IsNullOrEmpty(AgeFilter))
            {
                return View(await _context.Employee.ToListAsync());
            }
            else
            {
                switch (AgeFilter)
                {
                    case "under20":
                        employees = await _context.Employee
                            .Where(e => e.Age < 20)
                            .ToListAsync();
                        break;
                    case "20to25":
                        employees = await _context.Employee
                            .Where(e => e.Age >= 20 && e.Age <= 25)
                            .ToListAsync();
                        break;
                    case "above25":
                        employees = await _context.Employee
                            .Where(e => e.Age > 25)
                            .ToListAsync();
                        break;
                    default:
                        employees = await _context.Employee.ToListAsync();
                        break;
                }

                return View(employees);
            }
            
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
             Employee employee = new Employee();
             string LastId= _context.Employee.Max(e => e.EmployeeId);
             employee.EmployeeId = AutoId.AutoId.GetNextId(LastId);
             ViewBag.Message =  employee.EmployeeId;
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Age,FullName,Address,Email")] Employee employee)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EmployeeId,Age,Id,FullName,Address,Email")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee != null)
            {
                _context.Employee.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

         [HttpGet]
         public IActionResult Find()
        {
        return View();
        }
        [HttpPost]
        public async Task<IActionResult> Find(string Search, Employee employee)
        {
            if (Search == null)
            {
                return NotFound();
            }

            var emp = await _context.Employee
            .FirstOrDefaultAsync(e => e.FullName == Search);

            if (emp == null)
            {
                var emps = await _context.Employee
                .FirstOrDefaultAsync(e => e.EmployeeId == Search);
                return View(emps);
            }


            return View(emp);
        }
        

    

        private bool EmployeeExists(string id)
        {
            return _context.Employee.Any(e => e.EmployeeId == id);
        }
    }
}
