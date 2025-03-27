using Assigment_PRN222_01.DAO;
using Assigment_PRN222_01.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Assigment_PRN222_01.Service
{
    public class AuthService
    {
        private readonly AdminAccountSettings _adminAccount;
        private readonly FunewsManagementContext _context;

        public AuthService(IOptions<AdminAccountSettings> adminAccountOptions, FunewsManagementContext context)
        {
            _adminAccount = adminAccountOptions.Value;
            _context = context;
        }

        public SystemAccount AuthenticateAsync(string email, string password)
        {
            var hasher = new PasswordHasher<SystemAccount>();

            // Kiểm tra tài khoản admin từ appsettings.json
            if (email == _adminAccount.Email && password == _adminAccount.Password)
            {
                var admin = new SystemAccount
                {
                    AccountEmail = email,
                    AccountPassword = password,
                    AccountRole = 0
                };
                return admin;
            }
            // Kiểm tra tài khoản từ database
            var user = _context.SystemAccounts.FirstOrDefault(u => u.AccountEmail == email);
            if (user != null)
            {
                var result = password.Equals(user.AccountPassword);
                return user;
            }
            return null;
        }
    }
}
