using Microsoft.EntityFrameworkCore;
using RestaurantBusiness.Models;


namespace RestaurantDataAccess.Dao
{
    public class UserDAO
    {
        private readonly Sp25Prn222RestaurantContext _context;

        public UserDAO(Sp25Prn222RestaurantContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
            {
                return null;
            }

            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

                return user;

            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Login Error: " + ex.Message);
                return null;
            }


        }
    }
}
