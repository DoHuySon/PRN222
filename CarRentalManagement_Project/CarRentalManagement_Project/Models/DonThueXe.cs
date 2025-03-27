using System;
using System.Collections.Generic;

namespace CarRentalManagement_Project.Models;

public partial class DonThueXe
{
    public int MaDonThue { get; set; }

    public int? MaKhachHang { get; set; }

    public int? MaXe { get; set; }

    public DateOnly NgayBatDau { get; set; }

    public DateOnly NgayKetThuc { get; set; }

    public decimal TongGiaThue { get; set; }

    public string TinhTrang { get; set; } = null!;

    public string DiaDiemNhanXe { get; set; } = null!;

    public string DiaDiemTraXe { get; set; } = null!;

    public virtual ICollection<BaoHiem> BaoHiems { get; set; } = new List<BaoHiem>();

    public virtual KhachHang? MaKhachHangNavigation { get; set; }

    public virtual Xe? MaXeNavigation { get; set; }

    public virtual ICollection<ThanhToan> ThanhToans { get; set; } = new List<ThanhToan>();
}
