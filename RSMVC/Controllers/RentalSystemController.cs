using System;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RSMVC.Models;

namespace RSMVC.Controllers
{
    public class RentalSystemController : Controller
    {
       
        readonly static HttpClient client = new();


       
        public async Task<IActionResult> Index()
        {
            List<RentalInfoSystem> rentalSystems = new();
            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync("https://localhost:7121/api/rentalsystem");
                string apiResponse = await response.Content.ReadAsStringAsync();
                rentalSystems = JsonConvert.DeserializeObject<List<RentalInfoSystem>>(apiResponse);
            }

            return View(rentalSystems);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            RentalInfoSystem rental = null;
            HttpResponseMessage response = await client.GetAsync("https://localhost:7121/api/rentalsystem/" + id);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                rental = JsonConvert.DeserializeObject<RentalInfoSystem>(apiResponse);
            }


            return View(rental);
        }

        public ViewResult FindRentalByName() => View();

        [HttpPost]
        public async Task<IActionResult> FindRentalByName(string name)
        {

            List<RentalInfoSystem> rental = new();

            HttpResponseMessage response = await client.GetAsync("https://localhost:7121/api/rentalsystem/search?name=" + name);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                rental = JsonConvert.DeserializeObject<List<RentalInfoSystem>>(apiResponse);
            }


            return View(rental);
        }


        public async Task<IActionResult> RentAnItem(int id)
        {
            RentalInfoSystem rental = new RentalInfoSystem();


            Item item = new Item();
            TryUpdateModelAsync(item);

            ViewBag.item = item.Name;
            rental.Item = item;
            rental.Item.Name = item.Name;
            rental.Item.Description = item.Description;
            rental.Item.Price = item.Price;
            UserDto user = TempData["mydata"] as UserDto;
            ViewData["mydata"] = JsonConvert.DeserializeObject<UserDto>((string)TempData["mydata"]); 

            return View(rental);
        }
        

        //[HttpPost]
        //public async Task<IActionResult> RentAnItem(RentalInfoSystem rental)
        //{
        //    RentalInfoSystem rentalRecieved = new RentalInfoSystem();

        //    using (var HttpClient = new HttpClient())
        //    {
        //        StringContent content = new StringContent(JsonConvert.SerializeObject(rental), Encoding.UTF8,
        //            "application/json");
        //        using (var response = await HttpClient.PostAsync("https://localhost:7121/api/rentalsystem", content))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            rentalRecieved = JsonConvert.DeserializeObject<RentalInfoSystem>(apiResponse);

        //        }
        //    }

        //    return View(rentalRecieved);
        //}

    }
}
