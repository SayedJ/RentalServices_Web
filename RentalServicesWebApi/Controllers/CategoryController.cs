using Microsoft.AspNetCore.Mvc;
using RentalServicesWebApi.Models;
using RentalServicesWebApi.Repository;

namespace RentalServicesWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var category = await _unitOfWork.Category.GetAll();
            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            var category = await _unitOfWork.Category.Get(id);
            if (category == null)
                return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Category.Add(category);
                await _unitOfWork.CompleteAsync();
                return CreatedAtAction("GetCategory", new { category.Id }, category);
            }

            return new JsonResult("Something Went Wrong") { StatusCode = 500 };

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _unitOfWork.Category.Get(id);
            if (category == null)
                return BadRequest();
            
            await _unitOfWork.Category.Remove(id);
            await _unitOfWork.CompleteAsync();

            return Ok(category);
        }
    }
}
