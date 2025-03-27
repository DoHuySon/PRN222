using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantBusiness.Models;
using RestaurantRepositories.IRepository;
using System.ComponentModel.DataAnnotations;

namespace SP25_PRN222_Restaurant.Pages
{
    public class TableManagementModel : PageModel
    {
        private readonly ITableRepository _tableRepository;

        public TableManagementModel(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository ?? throw new ArgumentNullException(nameof(tableRepository));
        }

        [BindProperty]
        [Required(ErrorMessage = "Table number is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Table number must be at least 1.")]
        public int TableNumber { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Number of seats is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of seats must be at least 1.")]
        public int Seats { get; set; }

        public List<Table> Tables { get; set; } = new List<Table>();

        public string Message { get; set; }

        public bool IsAdmin => HttpContext.Session.GetString("UserEmail") != null &&
                               (HttpContext.Session.GetString("UserRole") == "Admin");

        public async Task OnGetAsync()
        {
            // Load all tables for viewing
            Tables = await _tableRepository.SearchTablesBySeatsAsync(0); // 0 to get all tables
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!IsAdmin)
            {
                Message = "You do not have permission to add tables.";
                Tables = await _tableRepository.SearchTablesBySeatsAsync(0);
                return Page();
            }

            if (!ModelState.IsValid)
            {
                Tables = await _tableRepository.SearchTablesBySeatsAsync(0);
                return Page();
            }

            // Validate: Is the table number unique?
            if (await _tableRepository.TableNumberExistsAsync(TableNumber))
            {
                ModelState.AddModelError("TableNumber", "Table number must be unique.");
                Tables = await _tableRepository.SearchTablesBySeatsAsync(0);
                return Page();
            }

            // Create and save the new table
            var table = new Table
            {
                TableNumber = TableNumber,
                Seats = Seats,
                Status = "Available", // Default status
                CreatedAt = DateTime.Now
            };

            await _tableRepository.AddTableAsync(table);

            // Reload the table list
            Tables = await _tableRepository.SearchTablesBySeatsAsync(0);

            Message = "Table successfully added!";
            return Page();
        }
    }
}