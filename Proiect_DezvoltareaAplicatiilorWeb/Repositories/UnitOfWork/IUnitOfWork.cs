using Proiect_DezvoltareaAplicatiilorWeb.Repositories.AddressRepository;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.MovieRentalRepository;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.MovieRepository;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.RentalRepository;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.UserRepository;

namespace Proiect_DezvoltareaAplicatiilorWeb.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsync();
        IUserRepository userRepository { get; }
        IAddressRepository addressRepository { get; }
        IMovieRepository movieRepository { get; }
        IMovieRentalRepository movieRentalRepository { get; }
        IRentalRepository rentalRepository { get; }
    }
}
