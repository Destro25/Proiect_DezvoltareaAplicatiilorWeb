using Proiect_DezvoltareaAplicatiilorWeb.Models;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.GenericRepository;

namespace Proiect_DezvoltareaAplicatiilorWeb.Repositories.RentalRepository
{
    public interface IRentalRepository : IGenericRepository<Rental>
    {
        public Task<List<Rental>> GetAllMovieRentals();
    }
}
