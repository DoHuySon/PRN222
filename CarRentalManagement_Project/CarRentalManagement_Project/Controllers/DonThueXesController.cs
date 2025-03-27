using Microsoft.AspNetCore.Mvc;
using CarRentalManagement_Project.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagement_Project.Controllers
{
    public class DonThueXesController : Controller
    {
        private readonly QuanLyThueXeContext _context; // Thay bằng DbContext thực tế của bạn

        public DonThueXesController(QuanLyThueXeContext context)
        {
            _context = context;
        }

        // GET: Hiển thị form đăng ký thuê xe
        public IActionResult CreateDonThueXe(int maXe)
        {
            var xe = _context.Xes
                .Include(x => x.MaLoaiXeNavigation)
                .FirstOrDefault(x => x.MaXe == maXe);

            if (xe == null)
            {
                return NotFound();
            }

            var donThueXe = new DonThueXe
            {
                MaXe = maXe,
                NgayBatDau = DateOnly.FromDateTime(DateTime.Now),
                NgayKetThuc = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                TongGiaThue = xe.GiaThueMotNgay
            };

            ViewBag.Xe = xe;
            ViewBag.KhachHangList = _context.KhachHangs.ToList();
            return View(donThueXe);
        }

        // POST: Xử lý khi submit form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDonThueXe(DonThueXe donThueXe)
        {
            if (ModelState.IsValid)
            {
                // Tính tổng giá thuê dựa trên số ngày
                var xe = _context.Xes.Find(donThueXe.MaXe);
                var days = (donThueXe.NgayKetThuc.ToDateTime(TimeOnly.MinValue) - donThueXe.NgayBatDau.ToDateTime(TimeOnly.MinValue)).Days;
                donThueXe.TongGiaThue = xe.GiaThueMotNgay * days;

                donThueXe.TinhTrang = "Chờ xác nhận"; // Trạng thái mặc định
                _context.DonThueXes.Add(donThueXe);
                _context.SaveChanges();
                return RedirectToAction("Index", "Xes"); // Chuyển về danh sách xe sau khi lưu
            }

            ViewBag.Xe = _context.Xes.Find(donThueXe.MaXe);
            ViewBag.KhachHangList = _context.KhachHangs.ToList();
            return View(donThueXe);
        }
    }
}