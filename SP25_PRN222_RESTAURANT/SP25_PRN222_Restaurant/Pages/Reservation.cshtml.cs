using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantBusiness.Models;
using RestaurantRepositories.IRepository;
using System.ComponentModel.DataAnnotations;

namespace SP25_PRN222_Restaurant.Pages
{
    public class ReservationModel : PageModel
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ITableRepository _tableRepository;

        public ReservationModel(IReservationRepository reservationRepository, ITableRepository tableRepository)
        {
            _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
            _tableRepository = tableRepository ?? throw new ArgumentNullException(nameof(tableRepository));
        }

        [BindProperty]
        [Required(ErrorMessage = "Please select a table.")]
        public int TableId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please select a reservation date and time.")]
        [DataType(DataType.DateTime)]
        public DateTime ReservationDate { get; set; }

        public List<Table> AvailableTables { get; set; } = new List<Table>();
        public List<Reservation> UserReservations { get; set; } = new List<Reservation>();

        public string Message { get; set; }

        public int UserId => HttpContext.Session.GetInt32("UserId") ?? 0;

        public bool IsCustomer => HttpContext.Session.GetString("UserEmail") != null &&
                                  (HttpContext.Session.GetString("UserRole") == "Customer");

        public async Task OnGetAsync()
        {
            if (!IsCustomer)
            {
                Message = "You must be logged in as a customer to make a reservation.";
                return;
            }

            // Load available tables (status = "Available")
            AvailableTables = await _tableRepository.SearchTablesBySeatsAsync(0); // 0 to get all tables
            AvailableTables = AvailableTables.Where(t => t.Status == "Available").ToList();

            // Load the user's reservations
            UserReservations = await _reservationRepository.GetReservationsByUserAsync(UserId);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!IsCustomer)
            {
                Message = "You must be logged in as a customer to make a reservation.";
                return Page();
            }

            if (!ModelState.IsValid)
            {
                AvailableTables = await _tableRepository.SearchTablesBySeatsAsync(0);
                AvailableTables = AvailableTables.Where(t => t.Status == "Available").ToList();
                UserReservations = await _reservationRepository.GetReservationsByUserAsync(UserId);
                return Page();
            }

            // Validate: Is the table still available?
            bool isTableAvailable = await _reservationRepository.IsTableAvailableAsync(TableId, ReservationDate);
            if (!isTableAvailable)
            {
                Message = "The selected table is no longer available for the chosen time.";
                AvailableTables = await _tableRepository.SearchTablesBySeatsAsync(0);
                AvailableTables = AvailableTables.Where(t => t.Status == "Available").ToList();
                UserReservations = await _reservationRepository.GetReservationsByUserAsync(UserId);
                return Page();
            }

            // Validate: Does the customer already have a reservation at this time?
            bool hasExistingReservation = await _reservationRepository.HasExistingReservationAsync(UserId, ReservationDate);
            if (hasExistingReservation)
            {
                Message = "You already have a reservation at this time.";
                AvailableTables = await _tableRepository.SearchTablesBySeatsAsync(0);
                AvailableTables = AvailableTables.Where(t => t.Status == "Available").ToList();
                UserReservations = await _reservationRepository.GetReservationsByUserAsync(UserId);
                return Page();
            }

            // Create and save the reservation
            var reservation = new Reservation
            {
                UserId = UserId,
                TableId = TableId,
                ReservationDate = ReservationDate,
                Status = "Pending", // Initial status
                CreatedAt = DateTime.Now
            };

            await _reservationRepository.AddReservationAsync(reservation);

            // Update the table status to "Reserved"
            await _tableRepository.UpdateTableStatusAsync(TableId, "Reserved");

            // Reload the user’s reservations
            UserReservations = await _reservationRepository.GetReservationsByUserAsync(UserId);
            AvailableTables = await _tableRepository.SearchTablesBySeatsAsync(0);
            AvailableTables = AvailableTables.Where(t => t.Status == "Available").ToList();

            Message = "Reservation successfully created!";
            return Page();
        }
    }
}