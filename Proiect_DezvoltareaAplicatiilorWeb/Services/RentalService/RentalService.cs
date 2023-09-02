using AutoMapper;
using Proiect_DezvoltareaAplicatiilorWeb.Models;
using Proiect_DezvoltareaAplicatiilorWeb.Models.DTOs;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.UnitOfWork;

namespace Proiect_DezvoltareaAplicatiilorWeb.Services.RentalService
{
    public class RentalService : IRentalService
    {
        public IUnitOfWork UnitOfWork;
        public IMapper Mapper;
        public RentalService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task Create(RentalDTO rental)
        {
            var user = UnitOfWork.userRepository.GetUserByEmail(rental.UserEmail);

            var rent = new Rental
            {
                RentalDate = rental.RentalDate,
                ReturnDate = rental.ReturnDate,
                RentalCost = rental.RentalCost,
                User = user,
                UserId = user.Id,
            };
            await UnitOfWork.rentalRepository.CreateAsync(rent);
            await UnitOfWork.rentalRepository.SaveAsync();
        }
        public async Task Delete(Guid Id)
        {
            var rent = await UnitOfWork.rentalRepository.FindByIdAsync(Id);
            UnitOfWork.rentalRepository.Delete(rent);
            await UnitOfWork.rentalRepository.SaveAsync();
        }
        public async Task<List<Rental>> GetAll()
        {
            return await UnitOfWork.rentalRepository.GetAll();
        }
        public async Task<Rental> GetById (Guid Id)
        {
            return await UnitOfWork.rentalRepository.FindByIdAsync(Id);
        }

        public async Task<Rental>? Update(Guid Id, RentalDTO rental)
        {
            var rent = await UnitOfWork.rentalRepository.FindByIdAsync(Id);

            if (rental == null)
            {
                return null;
            }

            rent.ReturnDate = rental.ReturnDate;
            rent.RentalDate = rental.RentalDate;
            rent.RentalCost = rental.RentalCost;

            await UnitOfWork.rentalRepository.SaveAsync();
            return rent;
        }

        public async Task<List<Rental>> GetAllMovieRentals()
        {
            return await UnitOfWork.rentalRepository.GetAllMovieRentals();
        }
    }
}
