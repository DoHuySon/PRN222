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
    public class ReservationRepository : IReservationRepository
    {
        private readonly ReservationDAO _reservationDAO;

        public ReservationRepository(ReservationDAO reservationDAO)
        {
            _reservationDAO = reservationDAO;
        }

        public async Task AddReservationAsync(Reservation reservation)
        {
            await _reservationDAO.AddReservationAsync(reservation);
        }

        public Task<List<Reservation>> GetReservationsByUserAsync(int userId)
        {
            return _reservationDAO.GetReservationByUserAsync(userId);
        }

        public Task<bool> HasExistingReservationAsync(int userId, DateTime time)
        {
            return _reservationDAO.HasExistingReservationAsync(userId, time);
        }

        public Task<bool> IsTableAvailableAsync(int tableId, DateTime time)
        {
            return _reservationDAO.IsTableAvailableAsync(tableId, time);
        }
    }
}
