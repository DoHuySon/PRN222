using RestaurantBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRepositories.IRepository
{
    public interface IUserRepository
    {
        Task<User> Login(string email, string password); 
    }
}
