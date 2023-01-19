using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RSMVC.Models;

namespace RSMVC.Controllers
{
    public class ItemController : Controller
    {


        readonly static HttpClient client = new ();
        public async Task<IActionResult> Index()
        {
            List<Item> itemsList;
            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync("https://localhost:7121/api/item");
                string apiResponse = await response.Content.ReadAsStringAsync();
                itemsList = JsonConvert.DeserializeObject<List<Item>>(apiResponse);
            }

            return View(itemsList);
        }

       

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Item item = null;
            HttpResponseMessage response = await client.GetAsync("https://localhost:7121/api/item/" + id);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                item = JsonConvert.DeserializeObject<Item>(apiResponse);
                item.Availability.ToString();
            }
           
            
            return View(item);
        }
        
        public ViewResult FindItemsByName() => View();

        [HttpPost]
        public async Task<IActionResult> FindItemsByName(string name)
        {

            List<Item> items = new ();

            HttpResponseMessage response = await client.GetAsync("https://localhost:7121/api/item/search?name=" + name);
                
                if(response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<Item>>(apiResponse);
                }


                return View(items);
        }

        public async Task<IActionResult> GoForRent(int id)
        {
            Item item = null;
            HttpResponseMessage response = await client.GetAsync("https://localhost:7121/api/item/" + id);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                item = JsonConvert.DeserializeObject<Item>(apiResponse);
            }

           // TempData["selectedItem"] = item;

            return RedirectToAction("RentAnItem", "RentalSystem", item);

        }

        public async Task<IActionResult> UpdateItem(Item item)
        {
            string jsonItem = JsonConvert.SerializeObject(item);
            StringContent content = new StringContent(jsonItem, Encoding.UTF8, "application/json");
            var res = client.PutAsync("https://localhost:7121/api/item/"+ item.Id, content).Result;
            return View(res);
        }

        public ViewResult AddFile() => View();

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile file)
        {
            string apiResponse = "";
            using (var httpClient = new HttpClient())
            {
                var form = new MultipartFormDataContent();
                await using var fileStream = file.OpenReadStream();
                form.Add(new StreamContent(fileStream), "file", file.FileName);
                using var response = await httpClient.PostAsync("https://localhost:7121/api/item/UploadFile", form);
                response.EnsureSuccessStatusCode();
                apiResponse = await response.Content.ReadAsStringAsync();
            }
            return View((object)apiResponse);




        }
    
    }


}
