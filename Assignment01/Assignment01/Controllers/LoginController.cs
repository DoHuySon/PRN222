using Assignment01.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment01.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuthService _authService;

        public LoginController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (await _authService.AuthenticateAsync(email, password))
            {
                ViewBag.Message = "Đăng nhập thành công!";
                return View("Index");
            }

            ViewBag.Message = "Sai email hoặc mật khẩu!";
            return View("Index");
        }
    }
}
