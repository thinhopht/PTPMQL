using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;

namespace DemoMVC.Controllers;

public class Bai2 : Controller
{
    private readonly ILogger<Bai2> _logger;

    public Bai2(ILogger<Bai2> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

[HttpPost]
    public IActionResult Index(string So1, string So2, string Operator )
    {
        double result = 0;
        double num1 = double.Parse(So1);
        double num2 = double.Parse(So2);
           switch (Operator)
        {
            case "+": result = num1 + num2; break;
            case "-": result = num1 - num2; break;
            case "*": result = num1 * num2; break;
            case "/": result = (double)num1 / num2; break;
        }
    
    // string strOutput = "Kết quả của phép tính trên= "  + result;
    ViewBag.Message = result;
    return View();
    }
    
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}