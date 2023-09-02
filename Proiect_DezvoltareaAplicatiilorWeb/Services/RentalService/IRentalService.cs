using Proiect_DezvoltareaAplicatiilorWeb.Models;
using Proiect_DezvoltareaAplicatiilorWeb.Models.DTOs;

namespace Proiect_DezvoltareaAplicatiilorWeb.Services.RentalService
{
    public interface IRentalService
    {
        Task Create(RentalDTO rental);
        Task Delete(Guid id);
        Task<List<Rental>> GetAll();
        Task<Rental> GetById(Guid id);
        Task<Rental>? Update(Guid id, RentalDTO rental);
        Task<List<Rental>> GetAllMovieRentals();
    }
}
