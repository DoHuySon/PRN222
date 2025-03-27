using RestaurantBusiness.Models;


namespace RestaurantRepositories.IRepository
{
    public interface ITableRepository
    {
        Task<List<Table>> SearchTablesBySeatsAsync(int seats);
        Task UpdateTableStatusAsync(int tableId, string status);
        Task<bool> TableNumberExistsAsync(int tableNumber);
        Task AddTableAsync(Table table);
    }
}
