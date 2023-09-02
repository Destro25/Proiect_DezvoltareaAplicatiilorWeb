using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect_DezvoltareaAplicatiilorWeb.Models.DTOs;
using Proiect_DezvoltareaAplicatiilorWeb.Services.RentalService;

namespace Proiect_DezvoltareaAplicatiilorWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        public readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPut("update-rental")]
        //[Authorization(Role.Admin)]
        public async Task<IActionResult> UpdateRental(RentalDTO rent, Guid rentalId)
        {
            var rental = await _rentalService.Update(rentalId, rent);
            if (rental == null)
            {
                return NotFound();
            }
            return Ok(rental);
        }

        [HttpGet("get-all-rentals")]
        //[Authorization(Role.Admin)]
        public async Task<IActionResult> GetAllRentals()
        {
            return Ok(_rentalService.GetAll());
        }

        [HttpPost("make-a-rental")]
        //[Authorization(Role.Admin)]
        public async Task<IActionResult> AddRental(RentalDTO rent)
        {
            await _rentalService.Create(rent);
            return Ok(rent);
        }

        [HttpDelete("delete-rental")]
        //[Authorization(Role.Admin)]
        public async Task<IActionResult> DeleteRental(Guid Id)
        {
            await _rentalService.Delete(Id);
            return Ok("Rental was succesfully deleted.");
        }

        /*
        [HttpGet("get-rentals-and-movies")]
        public async Task<IActionResult> GetRentsAndMovs()
        {
            var rents = _rentalService.GetAllMovieRentals();
            return Ok(rents);
        }
        */
    }
}
