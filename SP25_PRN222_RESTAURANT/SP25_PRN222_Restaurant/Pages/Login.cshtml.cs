using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantRepositories.IRepository;
using System.ComponentModel.DataAnnotations;

namespace SP25_PRN222_Restaurant.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public LoginModel(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        [BindProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            if (HttpContext.Session.GetString("UserEmail") != null)
            {
                Response.Redirect("/Index");
            }
        }

        // Handle login form submission
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userRepository.Login(Email, Password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserEmail", user.Email);
                HttpContext.Session.SetString("UserFullName", user.FullName);
                HttpContext.Session.SetString("UserRole", user.Role);
                HttpContext.Session.SetInt32("UserId", user.Id);
                return RedirectToPage("/Index");
            }
            else
            {
                ErrorMessage = "Invalid email or password.";
                return Page();
            }
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear(); 
            return RedirectToPage("/Index"); 
        }
    }
}