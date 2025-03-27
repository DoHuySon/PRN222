using System;
using System.Collections.Generic;

namespace CarRentalManagement_Project.Models;

public partial class NhanVien
{
    public int MaNhanVien { get; set; }

    public string HoTen { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string SoDienThoai { get; set; } = null!;

    public string ChucVu { get; set; } = null!;

    public DateOnly NgayVaoLam { get; set; }
}
