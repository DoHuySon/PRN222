using RestaurantBusiness.Models;
using RestaurantDataAccess.Dao;
using RestaurantRepositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRepositories.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDAO _userDAO;

        public UserRepository(UserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        public Task<User> Login(string email, string password)
        {
            return _userDAO.Login(email, password);
        }
    }
}
