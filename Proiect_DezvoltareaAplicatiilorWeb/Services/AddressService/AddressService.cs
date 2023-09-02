using Proiect_DezvoltareaAplicatiilorWeb.Models;
using Proiect_DezvoltareaAplicatiilorWeb.Models.DTOs;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.UnitOfWork;

namespace Proiect_DezvoltareaAplicatiilorWeb.Services.AddressService
{
    public class AddressService : IAddressService
    {
        public IUnitOfWork UnitOfWork;

        public AddressService(IUnitOfWork unitOfWork) 
        {
            UnitOfWork = unitOfWork;
        }

        public async Task Create(Address address)
        {
            await UnitOfWork.addressRepository.CreateAsync(address);
            await UnitOfWork.addressRepository.SaveAsync();
        }

        public async Task Delete(Guid Id)
        {
            var address = await UnitOfWork.addressRepository.FindByIdAsync(Id);
            UnitOfWork.addressRepository.Delete(address);
            await UnitOfWork.addressRepository.SaveAsync();
        }

        public async Task<List<Address>> GetAll()
        {
            return await UnitOfWork.addressRepository.GetAll();
        }

        public async Task<Address> GetById(Guid Id) 
        {
            return await UnitOfWork.addressRepository.FindByIdAsync(Id);
        }

        public async Task<Address>? Update(Guid Id, AddressDTO address)
        {
            var a = await UnitOfWork.addressRepository.FindByIdAsync(Id);
            if (a == null) { return null; }

            a.IntercomNumber = address.IntercomNumber;
            a.City = address.City;
            a.PostalCode = address.PostalCode;
            a.Street = address.Street;

            await UnitOfWork.addressRepository.SaveAsync();
            return a;
        }

        public IQueryable<CityAddressDTO> GetAdressesByCity()
        {
            return UnitOfWork.addressRepository.GetAdressesByCity();
        }
    }
}
