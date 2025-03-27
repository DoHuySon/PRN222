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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDonThueXe(DonThueXe donThueXe)
        {
            // Gán giá trị mặc định cho TinhTrang
            donThueXe.TinhTrang = "Đã Đặt";

            // Xóa lỗi validation của TinhTrang trong ModelState
            if (ModelState.ContainsKey("TinhTrang"))
            {
                ModelState.Remove("TinhTrang");
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                ViewBag.Errors = errors;
                ViewBag.Xe = _context.Xes.Find(donThueXe.MaXe);
                return View(donThueXe);
            }

            // Lấy thông tin khách hàng từ form
            var khachHang = donThueXe.MaKhachHangNavigation;

            // Debug: In ra thông tin khách hàng nhập vào
            Console.WriteLine($"Dữ liệu nhập vào - Email: '{khachHang.Email}', SoDienThoai: '{khachHang.SoDienThoai}', SoCMND: '{khachHang.SoCmnd}'");

            // Chuẩn hóa dữ liệu nhập vào
            var emailInput = khachHang.Email?.Trim().ToLower() ?? string.Empty;
            var soDienThoaiInput = khachHang.SoDienThoai?.Trim() ?? string.Empty;
            var soCmndInput = khachHang.SoCmnd?.Trim() ?? string.Empty;

            // Debug: In ra dữ liệu sau khi chuẩn hóa
            Console.WriteLine($"Dữ liệu chuẩn hóa - Email: '{emailInput}', SoDienThoai: '{soDienThoaiInput}', SoCMND: '{soCmndInput}'");

            //Kiểm tra khách hàng dựa trên Email, SoDienThoai, và SoCMND
            var existingCustomer = _context.KhachHangs
                .FirstOrDefault(k => (k.Email != null && k.Email.Trim().ToLower() == emailInput)
                                  && (k.SoDienThoai != null && k.SoDienThoai.Trim() == soDienThoaiInput)
                                  && (k.SoCmnd != null && k.SoCmnd.Trim() == soCmndInput));

            // Nếu khách hàng đã tồn tại, sử dụng khách hàng hiện có
            if (existingCustomer != null)
            {
                Console.WriteLine($"Tìm thấy khách hàng hiện có: MaKhachHang = {existingCustomer.MaKhachHang}, Email: '{existingCustomer.Email}', SoDienThoai: '{existingCustomer.SoDienThoai}', SoCMND: '{existingCustomer.SoCmnd}'");
                donThueXe.MaKhachHang = existingCustomer.MaKhachHang;
            }
            // Nếu không tìm thấy khách hàng, thêm mới
            else
            {
                Console.WriteLine("Không tìm thấy khách hàng, thêm mới...");
                _context.KhachHangs.Add(khachHang);
                _context.SaveChanges();
                donThueXe.MaKhachHang = khachHang.MaKhachHang;
            }

            var xe = _context.Xes.Find(donThueXe.MaXe);
            if (xe == null)
            {
                ModelState.AddModelError("", "Không tìm thấy xe.");
                ViewBag.Xe = xe;
                return View(donThueXe);
            }

            var days = (donThueXe.NgayKetThuc.ToDateTime(TimeOnly.MinValue) -
                        donThueXe.NgayBatDau.ToDateTime(TimeOnly.MinValue)).Days;
            if (days < 0)
            {
                ModelState.AddModelError("", "Ngày kết thúc phải sau ngày bắt đầu.");
                ViewBag.Xe = xe;
                return View(donThueXe);
            }

            donThueXe.TongGiaThue = xe.GiaThueMotNgay * days;

            _context.DonThueXes.Add(donThueXe);
            _context.SaveChanges();

            // Thêm thông báo vào TempData
            TempData["SuccessMessage"] = "Đã đặt xe thành công, vui lòng chờ cuộc gọi.";

            return RedirectToAction("Index", "Xes");
        }


    }
}