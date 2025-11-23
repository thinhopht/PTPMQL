using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Models.Process
{
    public class ProcessExcel
    {
        public IActionResult ImportExcel(IFormFile file)
    {
        return new EmptyResult();
    }
    }
}
