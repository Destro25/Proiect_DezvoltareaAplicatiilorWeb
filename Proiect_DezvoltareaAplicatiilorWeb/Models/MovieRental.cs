using Proiect_DezvoltareaAplicatiilorWeb.Models.Base;

namespace Proiect_DezvoltareaAplicatiilorWeb.Models
{
    public class MovieRental : BaseEntity
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public Guid RentalId { get; set; }
        public Rental Rental { get; set; }
    }
}
