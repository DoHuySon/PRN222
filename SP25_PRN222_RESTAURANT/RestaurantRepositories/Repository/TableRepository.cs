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
    public class TableRepository : ITableRepository
    {
        private readonly TableDAO _tableDAO;

        public TableRepository(TableDAO tableDAO)
        {
            _tableDAO = tableDAO;
        }

        public async Task AddTableAsync(Table table)
        {
            _tableDAO.AddTableAsync(table);
        }

        public Task<List<Table>> SearchTablesBySeatsAsync(int seats)
        {
            return _tableDAO.SearchTablesBySeatsAsync(seats);
        }

        public Task<bool> TableNumberExistsAsync(int tableNumber)
        {
            return _tableDAO.TableNumberExistsAsync(tableNumber);
        }

        public Task UpdateTableStatusAsync(int tableId, string status)
        {
            return _tableDAO.UpdateTablesStatusAsync(tableId, status);
        }
    }
}
