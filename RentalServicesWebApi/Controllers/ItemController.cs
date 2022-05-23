using Microsoft.AspNetCore.Mvc;
using RentalServicesWebApi.Models;
using RentalServicesWebApi.Repository;

namespace RentalServicesWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var item = await _unitOfWork.Items.GetAll();
            return Ok(item);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem([FromRoute] int id)
        {
            var item = await _unitOfWork.Items.Get(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] Item item)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Items.Add(item);
                await _unitOfWork.CompleteAsync();
                return CreatedAtAction("GetItem", new {item.Id}, item);
            }

            return new JsonResult("Something Went Wrong") {StatusCode = 500};
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _unitOfWork.Items.Get(id);
            if (item == null)
                return BadRequest();

            await _unitOfWork.Items.Remove(id);
            await _unitOfWork.CompleteAsync();

            return Ok(item);
        }
    }
}
