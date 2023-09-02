using AutoMapper;
using BCrypt.Net;
using Proiect_DezvoltareaAplicatiilorWeb.Helpers.JwtUtils;
using Proiect_DezvoltareaAplicatiilorWeb.Models;
using Proiect_DezvoltareaAplicatiilorWeb.Models.DTOs;
using Proiect_DezvoltareaAplicatiilorWeb.Models.Enums;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.UnitOfWork;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.UserRepository;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Proiect_DezvoltareaAplicatiilorWeb.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        public IJwtUtils JwtUtils;
        public IMapper Mapper;
        public IUnitOfWork UnitOfWork;

        public UserService(IMapper mapper, IJwtUtils jwtUtils, IUnitOfWork unitOfWork)
        {
            JwtUtils = jwtUtils;
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task Create(UserDTO newUser)
        {
            var user = Mapper.Map<User>(newUser);
            await UnitOfWork.userRepository.CreateAsync(user);
            await UnitOfWork.userRepository.SaveAsync();
        }

       public async Task Delete(Guid Id)
        {
            var user = await UnitOfWork.userRepository.FindByIdAsync(Id);
            UnitOfWork.userRepository.Delete(user);
            await UnitOfWork.userRepository.SaveAsync();
        }

        public Task<List<User>> GetAll()
        {
            return UnitOfWork.userRepository.GetAll();
        }

        public async Task<User> GetById(Guid Id)
        {
            return await UnitOfWork.userRepository.FindByIdAsync(Id);
        }

        public async Task<User>? Update(Guid Id, UserDTO user)
        {
            var u = await UnitOfWork.userRepository.FindByIdAsync(Id);

            if (u == null)
                return null;

            u.UserName = user.UserName;
            u.Email = user.Email;
            u.FirstName = user.FirstName;
            u.LastName = user.LastName;
            u.Address = user.Address;

            await UnitOfWork.userRepository.SaveAsync();

            return u;
        }

        public UserResponseDTO? Authenticate(UserRequestDTO user)
        {
            var _user = UnitOfWork.userRepository.GetUserByEmail(user.Email);
            if(_user == null || !BCryptNet.Verify(user.Password, _user.PasswordHash))
            {
                return null;
            }
            var jwtToken = JwtUtils.GenerateJwtToken(_user);
            return new UserResponseDTO(_user, jwtToken);
        }

        public async Task CreateAdmin(UserRequestDTO admin)
        {
            var newUser = Mapper.Map<User>(admin);
            newUser.PasswordHash = BCryptNet.HashPassword(admin.Password);
            newUser.Role = Role.Admin;

            await UnitOfWork.userRepository.CreateAsync(newUser);
            await UnitOfWork.userRepository.SaveAsync();
        }
        public async Task CreateUser(UserRequestDTO user)
        {
            var newUser = Mapper.Map<User>(user);
            newUser.PasswordHash = BCryptNet.HashPassword(user.Password);
            newUser.Role = Role.User;

            await UnitOfWork.userRepository.CreateAsync(newUser);
            await UnitOfWork.userRepository.SaveAsync();
        }
    }
}
