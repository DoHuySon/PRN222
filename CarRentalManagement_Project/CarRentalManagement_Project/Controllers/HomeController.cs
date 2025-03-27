using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarRentalManagement_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagement_Project.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly QuanLyThueXeContext _context;

    public HomeController(ILogger<HomeController> logger, QuanLyThueXeContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult View()
    {
        var listcar = _context.Xes
            .Take(8)
            .ToList();
        var loaixe = _context.LoaiXes.ToList();
        return View(listcar);
    }

    public IActionResult Privacy()
    {
        var listcar = _context.Xes
            .ToList();
        var loaixe = _context.LoaiXes.ToList();
        return View(listcar);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
