using RestaurantBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRepositories.IRepository
{
    public interface IReservationRepository
    {
        Task<bool> IsTableAvailableAsync(int tableId, DateTime time);
        Task<bool> HasExistingReservationAsync(int userId, DateTime time);
        Task AddReservationAsync(Reservation reservation);
        Task<List<Reservation>> GetReservationsByUserAsync(int userId);
    }
}
