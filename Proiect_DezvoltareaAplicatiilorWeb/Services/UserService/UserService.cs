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
        public IJwtUtils _jwtUtils;
        public IMapper _mapper;
        public IUnitOfWork _unitOfWork;

        public UserService(IMapper mapper, IJwtUtils jwtUtils, IUnitOfWork unitOfWork)
        {
            _jwtUtils = jwtUtils;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Create(UserDTO newUser)
        {
            var user = _mapper.Map<User>(newUser);
            await _unitOfWork.userRepository.CreateAsync(user);
            await _unitOfWork.userRepository.SaveAsync();
        }

       public async Task Delete(Guid Id)
        {
            var user = await _unitOfWork.userRepository.FindByIdAsync(Id);
            _unitOfWork.userRepository.Delete(user);
            await _unitOfWork.userRepository.SaveAsync();
        }

        public Task<List<User>> GetAll()
        {
            return _unitOfWork.userRepository.GetAll();
        }

        public async Task<User> GetById(Guid Id)
        {
            return await _unitOfWork.userRepository.FindByIdAsync(Id);
        }

        public async Task<User>? Update(Guid Id, UserDTO user)
        {
            var u = await _unitOfWork.userRepository.FindByIdAsync(Id);

            if (u == null)
                return null;

            u.UserName = user.UserName;
            u.Email = user.Email;
            u.FirstName = user.FirstName;
            u.LastName = user.LastName;
            u.Address = user.Address;

            await _unitOfWork.userRepository.SaveAsync();

            return u;
        }

        public UserResponseDTO? Authenticate(UserRequestDTO user)
        {
            var _user = _unitOfWork.userRepository.GetUserByEmail(user.Email);
            if(_user == null || !BCryptNet.Verify(user.Password, _user.PasswordHash))
            {
                return null;
            }
            var jwtToken = _jwtUtils.GenerateJwtToken(_user);
            return new UserResponseDTO(_user, jwtToken);
        }

        public async Task CreateAdmin(UserRequestDTO admin)
        {
            var newUser = _mapper.Map<User>(admin);
            newUser.PasswordHash = BCryptNet.HashPassword(admin.Password);
            newUser.Role = Role.Admin;

            await _unitOfWork.userRepository.CreateAsync(newUser);
            await _unitOfWork.userRepository.SaveAsync();
        }
        public async Task CreateUser(UserRequestDTO user)
        {
            var newUser = _mapper.Map<User>(user);
            newUser.PasswordHash = BCryptNet.HashPassword(user.Password);
            newUser.Role = Role.User;

            await _unitOfWork.userRepository.CreateAsync(newUser);
            await _unitOfWork.userRepository.SaveAsync();
        }
    }
}
