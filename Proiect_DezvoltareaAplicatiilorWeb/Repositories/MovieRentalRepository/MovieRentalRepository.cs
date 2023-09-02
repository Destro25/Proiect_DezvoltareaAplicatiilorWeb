using Proiect_DezvoltareaAplicatiilorWeb.Data;
using Proiect_DezvoltareaAplicatiilorWeb.Models;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.GenericRepository;

namespace Proiect_DezvoltareaAplicatiilorWeb.Repositories.MovieRentalRepository
{
    public class MovieRentalRepository : GenericRepository<MovieRental>, IMovieRentalRepository
    {
        public MovieRentalRepository(ProjectContext projectContext) : base(projectContext) { }
    }
}
