using System.Collections.Generic; // Cần thêm để sử dụng ICollection
using System.ComponentModel.DataAnnotations; // Cần thêm để sử dụng [Key]

namespace DemoMVC.Models
{
    public class HeThongPhanPhoi
    {
        [Key] 
        public string MaHTPP { get; set; }= string.Empty;
        public string TenHTPP { get; set; }= string.Empty;

    }
}