using Proiect_DezvoltareaAplicatiilorWeb.Models;
using Proiect_DezvoltareaAplicatiilorWeb.Models.DTOs;

namespace Proiect_DezvoltareaAplicatiilorWeb.Services.UserService
{
    public interface IUserService
    {
        Task Create(UserDTO user);
        Task Delete(Guid id);
        Task<List<User>> GetAll();
        Task<User> GetById(Guid id);
        Task<User>? Update(Guid id, UserDTO user);


        UserResponseDTO? Authenticate(UserRequestDTO user);

        Task CreateAdmin(UserRequestDTO admin);
        Task CreateUser(UserRequestDTO user);
    }
}
