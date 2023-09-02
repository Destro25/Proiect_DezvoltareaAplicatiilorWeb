using Proiect_DezvoltareaAplicatiilorWeb.Data;
using Proiect_DezvoltareaAplicatiilorWeb.Models;
using Proiect_DezvoltareaAplicatiilorWeb.Models.DTOs;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.GenericRepository;

namespace Proiect_DezvoltareaAplicatiilorWeb.Repositories.AddressRepository
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(ProjectContext projectContext) : base(projectContext) { }

        public IQueryable<CityAddressDTO> GetAdressesByCity()
        {
            var adrs = from address in _table
                       group address by address.City into groupingByCity
                       select new CityAddressDTO
                       {
                           City = groupingByCity.Key,
                           Counter = groupingByCity.Count()
                       };
            return adrs;
        }
    }
}
