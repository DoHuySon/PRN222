using System;
using System.Collections.Generic;

namespace CarRentalManagement_Project.Models;

public partial class KhachHang
{
    public int MaKhachHang { get; set; }

    public string HoTen { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string SoDienThoai { get; set; } = null!;

    public string SoCmnd { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public DateOnly NgaySinh { get; set; }

    public virtual ICollection<DonThueXe> DonThueXes { get; set; } = new List<DonThueXe>();
}
