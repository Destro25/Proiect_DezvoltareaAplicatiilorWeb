using Proiect_DezvoltareaAplicatiilorWeb.Models;
using Proiect_DezvoltareaAplicatiilorWeb.Models.DTOs;

namespace Proiect_DezvoltareaAplicatiilorWeb.Services.AddressService
{
    public interface IAddressService
    {
        Task Create(Address address);
        Task Delete(Guid Id);
        Task<List<Address>> GetAll();
        Task<Address> GetById(Guid Id);
        Task<Address>? Update(Guid Id, AddressDTO address);
        IQueryable<CityAddressDTO> GetAdressesByCity();
    }
}
