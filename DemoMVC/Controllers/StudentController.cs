using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;

namespace DemoMVC.Controllers;

    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            // Tạo danh sách giả lập (bình thường sẽ lấy từ DB)
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Nguyễn Văn A", Age = 20 ,Email = "THinhne2004@gmail.com"},
                new Student { Id = 2, Name = "Trần Văn B", Age = 21 },
                new Student { Id = 3, Name = "Lê Thị C", Age = 19 }
            };

            // Truyền danh sách sang View
            return View(students);
        }
    }
