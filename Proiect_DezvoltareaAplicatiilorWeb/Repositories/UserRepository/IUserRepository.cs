using Proiect_DezvoltareaAplicatiilorWeb.Models;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.GenericRepository;

namespace Proiect_DezvoltareaAplicatiilorWeb.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Guid GetUserId(string firstName, string lastName);
        public User GetUserByEmail(string email);
        public Task<List<User>> GetUserRentals();
    }
}
