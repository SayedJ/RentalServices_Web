using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RentalServicesWebApi.Helpers;
using RentalServicesWebApi.Models;
using RentalServicesWebApi.Repository;

namespace RentalServicesWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalSystemController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RentalSystemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
          
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rental = await _unitOfWork.RentalSystem.GetAll();
            return Ok(rental);
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> GetByName(string name)
        {
            var items = await _unitOfWork.RentalSystem.FindByName(name);
            if (items == null)
                return NotFound();
            return Ok(items);
        }

        

   
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRental(int id)
        {
            var rental = await _unitOfWork.RentalSystem.Get(id);
            if (rental == null)
                return BadRequest();

            await _unitOfWork.RentalSystem.Remove(id);
            await _unitOfWork.CompleteAsync();

            return Ok(rental);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateRental(BookingSystem rental)
        {
            var rentalExist = await _unitOfWork.RentalSystem.Find(x => x.Id == rental.Id);
            if (rentalExist == null)
                return BadRequest();
            await _unitOfWork.RentalSystem.Update(rental);
            await _unitOfWork.CompleteAsync();

            return Ok(rental);
        }
    }
}
