using System;
using System.Collections.Generic;

namespace CarRentalManagement_Project.Models;

public partial class ThanhToan
{
    public int MaThanhToan { get; set; }

    public int? MaDonThue { get; set; }

    public decimal SoTienThanhToan { get; set; }

    public string PhuongThucThanhToan { get; set; } = null!;

    public DateTime NgayThanhToan { get; set; }

    public string TrangThaiThanhToan { get; set; } = null!;

    public virtual DonThueXe? MaDonThueNavigation { get; set; }
}
