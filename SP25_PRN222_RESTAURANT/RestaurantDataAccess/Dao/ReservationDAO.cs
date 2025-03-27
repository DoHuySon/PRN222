using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDataAccess.Dao
{
    public class ReservationDAO
    {
        private readonly Sp25Prn222RestaurantContext _context;

        public ReservationDAO(Sp25Prn222RestaurantContext context)
        {
            _context = context;
        }

        public async Task<bool> IsTableAvailableAsync(int tableId, DateTime time)
        {
            var table = await _context.Tables.FindAsync(tableId);
            if (table == null || table.Status != "Available")
            {
                return false;
            }

            var existingReservation = await _context.Reservations
                        .Where(r => r.TableId == tableId && r.ReservationDate == time
                               && (r.Status == "Confirmed" || r.Status == "Pending")       
                        ).AnyAsync();
            return !existingReservation;
        }

        public async Task<bool> HasExistingReservationAsync(int userId, DateTime time)
        {
            return await _context.Reservations
                        .Where(r => r.UserId == userId && r.ReservationDate == time
                               && (r.Status == "Confirmed" || r.Status == "Pending")
                        ).AnyAsync();
        }

        public async Task AddReservationAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation); 
            _context.SaveChanges();
        }

        public async Task<List<Reservation>> GetReservationByUserAsync(int userId)
        {
            return await _context.Reservations.Where(r => r.UserId == userId).ToListAsync();
        }
    }
}
