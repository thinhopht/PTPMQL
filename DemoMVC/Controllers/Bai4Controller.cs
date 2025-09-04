// kiểm tra số nguyên tố
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using DemoMVC.Models;

namespace DemoMVC.Controllers;

public class Bai4Controller : Controller
{

    private readonly ILogger<Bai4Controller> _logger;

    public Bai4Controller(ILogger<Bai4Controller> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(string So)
    {
        int n = int.Parse(So);
        if (n < 0)
        {
            ViewBag.Message = So + " không phải số nguyên tố vì nó là số âm";
        }
        else if (n == 0 || n == 1)
        {
            ViewBag.Message = So + " không phải số nguyên tố";
        }
        else
        {
            bool isPrime = true;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
                ViewBag.Message = So + " là số nguyên tố";
            }
            else
            {
                ViewBag.Message = So + " không phải số nguyên tố";
            }
        }

        return View();
    }
}