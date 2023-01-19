using System.Diagnostics.CodeAnalysis;
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
        private readonly IWebHostEnvironment webHostEnvironment;

        public ItemController(IUnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            webHostEnvironment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var item = await _unitOfWork.Items.GetAll();
            return Ok(item);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var item = await _unitOfWork.Items.Get(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> GetByName(string name)
        {
             var items = await _unitOfWork.Items.FindByName(name);
            if (items == null)
                return NotFound();
            return Ok(items);
        }



            [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] Item item)
        {
            if (User.Identity.IsAuthenticated && ModelState.IsValid) { 
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
            if (item == null && !User.Identity.IsAuthenticated)
                return BadRequest();

            await _unitOfWork.Items.Remove(id);
            await _unitOfWork.CompleteAsync();

            return Ok(item);
        }

        [HttpPost("UploadFile")]
        public async Task<string> UploadFile([FromForm] IFormFile file)
        {
            string path = Path.Combine(webHostEnvironment.WebRootPath, "Images/" + file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return "https://localhost:7121/Images/" + file.FileName;
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateItem(Item item)
        {
            var itemExist = await _unitOfWork.RentalSystem.Find(x => x.Id == item.Id);
            if (itemExist == null)
                return BadRequest();
            await _unitOfWork.Items.Update(item);
            await _unitOfWork.CompleteAsync();

            return Ok(item);
        }
    }
}
