using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentalManagement_Project.Models;

namespace CarRentalManagement_Project.Controllers
{
    public class XesController : Controller
    {
        private readonly QuanLyThueXeContext _context;

        public XesController(QuanLyThueXeContext context)
        {
            _context = context;
        }

        // GET: Xes
        public async Task<IActionResult> Index()
        {
            var xeList = await _context.Xes
                .Include(x => x.MaLoaiXeNavigation)
                .ToListAsync();

            var loaiXeList = await _context.LoaiXes.ToListAsync();
            ViewBag.LoaiXeList = loaiXeList;
            ViewBag.SelectedMaLoaiXe = null;
            ViewBag.SelectedTrangThai = null;

            return View(xeList);
        }

        [HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> FilterCar(int? maLoaiXe)
        {
            Console.WriteLine($"MaLoaiXe: {maLoaiXe}");

            var xeList = await _context.Xes
                .Include(x => x.MaLoaiXeNavigation)
                .ToListAsync();

            if (maLoaiXe.HasValue)
            {
                xeList = xeList.Where(x => x.MaLoaiXe == maLoaiXe.Value).ToList();
            }

            var loaiXeList = await _context.LoaiXes.ToListAsync();
            ViewBag.LoaiXeList = loaiXeList;
            ViewBag.SelectedMaLoaiXe = maLoaiXe;
            ViewBag.SelectedTrangThai = HttpContext.Request.Query["TrangThai"].ToString();

            return View(xeList);
        }

        [HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> FilterByStatus(string trangThai)
        {
            Console.WriteLine($"TrangThai: {trangThai}");

            var xeList = await _context.Xes
                .Include(x => x.MaLoaiXeNavigation)
                .ToListAsync();

            if (!string.IsNullOrEmpty(trangThai))
            {
                xeList = xeList.Where(x => x.TrangThai == trangThai).ToList();
            }

            var loaiXeList = await _context.LoaiXes.ToListAsync();
            ViewBag.LoaiXeList = loaiXeList;
            ViewBag.SelectedMaLoaiXe = int.TryParse(HttpContext.Request.Query["MaLoaiXe"], out int maLoaiXe) ? (int?)maLoaiXe : null;
            ViewBag.SelectedTrangThai = trangThai;

            return View("FilterCar", xeList);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xe = await _context.Xes
                .Include(x => x.MaLoaiXeNavigation)
                .FirstOrDefaultAsync(m => m.MaXe == id);
            if (xe == null)
            {
                return NotFound();
            }

            return View(xe);
        }
    }
}