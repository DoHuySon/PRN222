using Microsoft.EntityFrameworkCore;
using RestaurantBusiness.Models;


namespace RestaurantDataAccess.Dao
{
    public class TableDAO
    {
        private readonly Sp25Prn222RestaurantContext _context;

        public TableDAO(Sp25Prn222RestaurantContext context)
        {
            _context = context;
        }

        public async Task<List<Table>> SearchTablesBySeatsAsync(int seats)
        {
            var tables = await _context.Tables
                .Where(t => t.Seats == seats)
                .ToListAsync();

            if (tables.Count == 0 && tables == null)
            {
                tables = await _context.Tables.ToListAsync();
            }

            return tables;
        }

        public async Task UpdateTablesStatusAsync(int tableId, string status)
        {
            var table = await _context.Tables.FindAsync(tableId);

            if (table != null)
            {
                table.Status = status;
                await _context.SaveChangesAsync();  
            }
        }

        public async Task AddTableAsync(Table table)
        {
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();  
        }

        public async Task<bool> TableNumberExistsAsync(int tableNumber)
        {
            return await _context.Tables.AnyAsync(t => t.TableNumber == tableNumber);
        }


    }
}
