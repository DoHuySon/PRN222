using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantRepositories.IRepository;
using System.ComponentModel.DataAnnotations;

namespace SP25_PRN222_Restaurant.Pages 
{
    public class TableSearchModel : PageModel
    {
        private readonly ITableRepository _tableRepository;

        public TableSearchModel(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository ?? throw new ArgumentNullException(nameof(tableRepository));
        }

        [BindProperty]
        [Required(ErrorMessage = "Please enter the number of seats.")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of seats must be at least 1.")]
        public int Seats { get; set; }

        public List<RestaurantBusiness.Models.Table> Tables { get; set; } = new List<RestaurantBusiness.Models.Table>();

        public string Message { get; set; }

        public bool IsAdmin => HttpContext.Session.GetString("UserEmail") != null &&
                               (HttpContext.Session.GetString("UserRole") == "Admin");

        public async Task OnGetAsync(int? seats)
        {
            if (seats.HasValue)
            {
                Seats = seats.Value; // Set the Seats property for the form
                Tables = await _tableRepository.SearchTablesBySeatsAsync(Seats);

                if (Tables == null || Tables.Count == 0)
                {
                    Message = "No tables found with the specified number of seats.";
                }
            }
        }

        public async Task<IActionResult> OnPostSearchAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Redirect to the same page with the seats parameter to preserve the search
            return RedirectToPage(new { seats = Seats });
        }

        public async Task<IActionResult> OnPostUpdateStatusAsync(int tableId, string status, int seat)
        {
            if (!IsAdmin)
            {
                ModelState.AddModelError(string.Empty, "You do not have permission to update table status.");
                return Page();
            }

            // Update table status in the repository
            await _tableRepository.UpdateTableStatusAsync(tableId, status);

            // Redirect back to the search page with the same 'Seats' search criteria
            return RedirectToPage(new { seats = seat });
        }

    }
}