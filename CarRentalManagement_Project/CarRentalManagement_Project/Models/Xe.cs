using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement_Project.Models;

public partial class Xe
{
    public int MaXe { get; set; }

    public string BienSoXe { get; set; } = null!;

    public int? MaLoaiXe { get; set; }

    public string HangXe { get; set; } = null!;

    public string MauXe { get; set; } = null!;

    public int NamSanXuat { get; set; }

    public string TrangThai { get; set; } = null!;
    [DisplayFormat(DataFormatString = "{0:N0}")]
    public decimal GiaThueMotNgay { get; set; }

    public int SoChoNgoi { get; set; }

    public string? HinhAnh { get; set; }

    public virtual ICollection<DonThueXe> DonThueXes { get; set; } = new List<DonThueXe>();

    public virtual LoaiXe? MaLoaiXeNavigation { get; set; }
}
