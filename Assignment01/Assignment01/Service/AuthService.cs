namespace Assignment01.Service
{
    using Assignment01.Controllers;
    using Assignment01.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using System.Threading.Tasks;

    public class AuthService
    {
        private readonly AdminAccountSettings _adminAccount;
        private readonly FunewsManagementContext _context;

        public AuthService(IOptions<AdminAccountSettings> adminAccountOptions, FunewsManagementContext context)
        {
            _adminAccount = adminAccountOptions.Value;
            _context = context;
        }

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            var hasher = new PasswordHasher<SystemAccount>();

            // Kiểm tra tài khoản admin từ appsettings.json
            if (email == _adminAccount.Email && password == _adminAccount.Password)
            {
                return true;
            }

            // Kiểm tra tài khoản từ database
            var user = await _context.SystemAccounts.FirstOrDefaultAsync(u => u.AccountEmail == email);
            if (user != null)
            {
                var result = hasher.VerifyHashedPassword(user, user.AccountPassword, password);
                return result == PasswordVerificationResult.Success;
            }

            return false;
        }
    }

}
