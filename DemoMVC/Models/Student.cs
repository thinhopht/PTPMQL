using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(1, 120)]
        public int Age { get; set; }

        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}