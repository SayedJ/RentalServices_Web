using Microsoft.AspNetCore.Mvc;
using RentalServicesWebApi.Models;
using RentalServicesWebApi.Repository;

namespace RentalServicesWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await _unitOfWork.Users.GetAll();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            var user = _unitOfWork.Users.Get(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> createUser([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Users.Add(user);
                await _unitOfWork.CompleteAsync();
                return CreatedAtAction("GetUser", new {user.Id}, user);
            }

            return new JsonResult("Something went wrong") {StatusCode = 500};
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _unitOfWork.Users.Get(id);
            if (user == null)
                return BadRequest();
            await _unitOfWork.Users.Remove(id);
            await _unitOfWork.CompleteAsync();
            return Ok(user);
        }


    }
}
