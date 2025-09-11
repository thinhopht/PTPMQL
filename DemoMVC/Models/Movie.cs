using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    // Class Movie
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public string Genre { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }

    // Class Person


    // Class HeThongPhanPhoi
    public class HeThongPhanPhoi
    {
        public string MaHTPP { get; set; } = string.Empty;
        public string TenHTPP { get; set; } = string.Empty;

        // Danh sách các DaiLy liên kết với hệ thống phân phối này
        public List<DaiLy> DaiLys { get; set; } = new List<DaiLy>();
    }

    // Class DaiLy liên kết với HeThongPhanPhoi
    public class DaiLy
    {
        public string MaDaiLy { get; set; } = string.Empty;
        public string TenDaiLy { get; set; } = string.Empty;
        public string DiaChi { get; set; } = string.Empty;
        public string NguoiDaiDien { get; set; } = string.Empty;
        public string DienThoai { get; set; } = string.Empty;

        // Khóa ngoại tới HeThongPhanPhoi
        public string MaHTPP { get; set; } = string.Empty;
        public HeThongPhanPhoi HeThongPhanPhoi { get; set; } = new HeThongPhanPhoi();
    }
}
