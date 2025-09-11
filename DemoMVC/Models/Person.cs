using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMVC.Models
{
    [Table ("Persons")] // Chỉ định tên bảng trong cơ sở dữ liệu
    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}