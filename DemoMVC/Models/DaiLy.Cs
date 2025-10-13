using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Cần thêm để sử dụng [ForeignKey]

namespace DemoMVC.Models
{
    public class DaiLy
    {
        [Key] // Đánh dấu MaDaiLy là khóa chính
        public string MaDaiLy { get; set; } = string.Empty;
        public string TenDaiLy { get; set; } = string.Empty;
        public string DiaChi { get; set; } = string.Empty;
        public string NguoiDaiDien { get; set; } = string.Empty;
        public string DienThoai { get; set; } = string.Empty;

        // --- Liên kết với Hệ Thống Phân Phối ---

        // 1. Khóa ngoại (Foreign Key)
        public string MaHTPP { get; set; } = string.Empty;

        // 2. Navigation property: Mỗi đại lý thuộc về MỘT hệ thống phân phối
        [ForeignKey("MaHTPP")]

        public virtual HeThongPhanPhoi HeThongPhanPhoi { get; set; } = null!;
    }   
}