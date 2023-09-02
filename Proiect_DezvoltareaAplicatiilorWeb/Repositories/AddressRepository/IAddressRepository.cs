using Proiect_DezvoltareaAplicatiilorWeb.Models;
using Proiect_DezvoltareaAplicatiilorWeb.Models.DTOs;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.GenericRepository;

namespace Proiect_DezvoltareaAplicatiilorWeb.Repositories.AddressRepository
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        public IQueryable<CityAddressDTO> GetAdressesByCity();
    }
}
