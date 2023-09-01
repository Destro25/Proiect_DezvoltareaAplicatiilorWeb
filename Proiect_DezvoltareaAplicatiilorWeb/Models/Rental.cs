using Proiect_DezvoltareaAplicatiilorWeb.Models.Base;

namespace Proiect_DezvoltareaAplicatiilorWeb.Models
{
    public class Rental : BaseEntity
    {
        public DateTime RentalDate { get; set; } = DateTime.UtcNow;
        public DateTime ReturnDate { get; set; }
        public double RentalCost { get; set; }
        public ICollection<MovieRental> MoviesRentals { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
