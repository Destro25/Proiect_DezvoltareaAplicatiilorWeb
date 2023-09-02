using Proiect_DezvoltareaAplicatiilorWeb.Data;
using Proiect_DezvoltareaAplicatiilorWeb.Models;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.GenericRepository;


namespace Proiect_DezvoltareaAplicatiilorWeb.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProjectContext projectContext) : base(projectContext) { }

        public Guid GetUserId(string firstName, string lastName)
        {
            var user = _table.FirstOrDefault(
                u => u.FirstName.ToLower().Equals(firstName.ToLower()) 
                && u.LastName.ToLower().Equals(lastName.ToLower()));
            if(user == null)
                return Guid.Empty;
            else
                return user.Id;
        }
        public User GetUserByEmail(string email)
        {
            return _table.FirstOrDefault(u => u.Email == email);
        }
        public async Task<List<User>> GetUserRentals()
        {
            var user = _table.Join(_projectContext.Rentals, user => user.Id, rental => rental.UserId,
                (user, rental) => new {user, rental}).Select(obj => obj.user);

            return user.ToList();
        }
    }
}
