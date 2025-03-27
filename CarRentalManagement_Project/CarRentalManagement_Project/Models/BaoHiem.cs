using System;
using System.Collections.Generic;

namespace CarRentalManagement_Project.Models;

public partial class BaoHiem
{
    public int MaBaoHiem { get; set; }

    public int? MaDonThue { get; set; }

    public string LoaiBaoHiem { get; set; } = null!;

    public decimal MucPhiBaoHiem { get; set; }

    public DateOnly NgayBatDau { get; set; }

    public DateOnly NgayKetThuc { get; set; }

    public virtual DonThueXe? MaDonThueNavigation { get; set; }
}
