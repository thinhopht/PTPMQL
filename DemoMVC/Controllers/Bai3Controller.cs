using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using DemoMVC.Models;

namespace DemoMVC.Controllers;

public class Bai3 : Controller
{
    private readonly ILogger<Bai3> _logger;

    public Bai3(ILogger<Bai3> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

[HttpPost]
    public IActionResult Index(string CanNang, string ChieuCao )
    {

       // Chuẩn hóa dấu thập phân
    CanNang = CanNang.Replace(",", ".");
    ChieuCao = ChieuCao.Replace(",", ".");

    double weight = double.Parse(CanNang, CultureInfo.InvariantCulture);
    double height = double.Parse(ChieuCao, CultureInfo.InvariantCulture);

    double bmi = weight / (height * height);

    // Format hiển thị 1 chữ số thập phân
    string bmiFormatted = bmi.ToString("0.0", CultureInfo.GetCultureInfo("vi-VN"));

    ViewBag.Message = "Kết quả BMI của bạn = " + bmiFormatted;

    return View();
    }
    
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}