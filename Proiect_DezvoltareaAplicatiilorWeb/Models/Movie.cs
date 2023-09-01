using Proiect_DezvoltareaAplicatiilorWeb.Models.Base;

namespace Proiect_DezvoltareaAplicatiilorWeb.Models
{
    public class Movie : BaseEntity
    {
        public string MovieName { get; set; }
        public string StudioName { get; set; }
        public double MovieLength { get; set; }

        public ICollection<MovieRental> MoviesRentals { get; set; }
    }
}
