using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMVC.Models
{
    [Table("Persons")]
    public class Person
    {
        [Key]
        public string Id { get; set; }= string.Empty;

        public string FullName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }

}