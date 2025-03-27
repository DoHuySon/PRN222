using Assigment_PRN222_01.Models;
using Assigment_PRN222_01.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assigment_PRN222_01.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuthService _authService;
        private readonly FunewsManagementContext _context;
        public LoginController(AuthService authService, FunewsManagementContext context)
        {
            _authService = authService;
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (_authService.AuthenticateAsync(email, password) != null)
            {
                var account = _authService.AuthenticateAsync(email, password);
                HttpContext.Session.SetString("email", email);

                /*if(_context.SystemAccounts.FirstOrDefault( m => m.AccountEmail.Equals(emailsession)) != null)
                {
                    var user = _context.SystemAccounts.FirstOrDefault(m => m.AccountEmail.Equals(emailsession));
                    var role = user.AccountRole;
                }
                else
                {
                    var role = 0;
                }*/
                string role = account.AccountRole.ToString();
                HttpContext.Session.SetString("Role", role);
                ViewData["email"] = account.AccountEmail;
                ViewBag.Message = "Đăng nhập thành công!";
                return View("~/Views/Home/Index.cshtml");
            }

            ViewBag.Message = "Sai email hoặc mật khẩu!";
            return View("Login");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Role");
            return View("Login");
        }
    }
}
