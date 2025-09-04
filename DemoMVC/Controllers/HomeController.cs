using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;

namespace DemoMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

[HttpPost]
    public IActionResult Index(string FullName, string Age)
    {
        int birthYear = int.Parse(Age);
        int ageCalculated = 2025 - birthYear;
    string strOutput = "Họ và tên: " + FullName + "  Số tuổi của bạn là: " + ageCalculated;
    ViewBag.Message = strOutput;
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