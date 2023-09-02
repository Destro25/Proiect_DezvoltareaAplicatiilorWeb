using AutoMapper;
using Proiect_DezvoltareaAplicatiilorWeb.Models;
using Proiect_DezvoltareaAplicatiilorWeb.Models.DTOs;

namespace Proiect_DezvoltareaAplicatiilorWeb.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Rental, RentalDTO>();
            CreateMap<RentalDTO, Rental>();

            CreateMap<Movie, MovieDTO>();
            CreateMap<MovieDTO, Movie>();

            CreateMap<Address, AddressDTO>();
            CreateMap<AddressDTO, Address>();

            CreateMap<MovieRental, MovieRentalDTO>();
            CreateMap<MovieRentalDTO, MovieRental>();

            CreateMap<User, UserRequestDTO>();
            CreateMap<UserRequestDTO, User>();

            CreateMap<User, UserResponseDTO>();
            CreateMap<UserResponseDTO, User>();
        }
    }
}
