using Microsoft.EntityFrameworkCore;
using Proiect_DezvoltareaAplicatiilorWeb.Data;
using Proiect_DezvoltareaAplicatiilorWeb.Models;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.GenericRepository;

namespace Proiect_DezvoltareaAplicatiilorWeb.Repositories.RentalRepository
{
    public class RentalRepository : GenericRepository<Rental>, IRentalRepository
    {
        public RentalRepository(ProjectContext projectContext) : base(projectContext) { }

        public async Task<List<Rental>> GetAllMovieRentals()
        {
            var rentals = _table.Include(r => r.MoviesRentals).ThenInclude(r => r.Movie).ToListAsync();
            return await rentals;
        }
    }
}
