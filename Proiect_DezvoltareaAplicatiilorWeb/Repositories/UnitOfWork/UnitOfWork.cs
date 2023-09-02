using Microsoft.Data.SqlClient;
using Proiect_DezvoltareaAplicatiilorWeb.Data;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.AddressRepository;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.MovieRentalRepository;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.MovieRepository;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.RentalRepository;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.UserRepository;

namespace Proiect_DezvoltareaAplicatiilorWeb.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository userRepository { get; set; }
        public IAddressRepository addressRepository { get; set; }
        public IMovieRepository movieRepository { get; set; }
        public IMovieRentalRepository movieRentalRepository { get; set; }
        public IRentalRepository rentalRepository { get; set; }

        private ProjectContext ProjectContext { get; set; }

        public UnitOfWork(IUserRepository userRepository, IAddressRepository addressRepository, IMovieRepository movieRepository, IMovieRentalRepository movieRentalRepository, IRentalRepository rentalRepository, ProjectContext projectContext)
        {
            this.userRepository = userRepository;
            this.addressRepository = addressRepository;
            this.movieRepository = movieRepository;
            this.movieRentalRepository = movieRentalRepository;
            this.rentalRepository = rentalRepository;
            this.ProjectContext = projectContext;
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return await ProjectContext.SaveChangesAsync() > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
