using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMVC.Models
{
    [Table("Employees")]
    public class Employee : Person
    {
        public int EmployeeId { get; set; }
        public int Age { get; set; }

    }
}