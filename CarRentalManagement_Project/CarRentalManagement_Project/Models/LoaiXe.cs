using System;
using System.Collections.Generic;

namespace CarRentalManagement_Project.Models;

public partial class LoaiXe
{
    public int MaLoaiXe { get; set; }

    public string TenLoaiXe { get; set; } = null!;

    public string? MoTa { get; set; }

    public virtual ICollection<Xe> Xes { get; set; } = new List<Xe>();
}
