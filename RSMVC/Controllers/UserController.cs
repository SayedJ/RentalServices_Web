

using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RSMVC.Models;


namespace RSMVC.Controllers
{
    public class UserController : Controller
    {


        
        [Authorize]
        public async Task<IActionResult> AllUsers()
        {
            List<ApplicationUser> users = new();

            string URL = "https://localhost:7121/api/users";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("user:user");
                string val = System.Convert.ToBase64String(plainTextBytes);

                httpClient.DefaultRequestHeaders.Add("Authorization", "basic " + val);

                using (var response = await httpClient.GetAsync(URL))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        users = JsonConvert.DeserializeObject<List<ApplicationUser>>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View(users);
        }
       
        public ViewResult GetAccount() => View();

        [HttpGet]
        [Route("getuser/{email=unnamed}")]
        public async Task<IActionResult> GetAccount(string email)
        {
            ApplicationUser user = new();
            string URL = "https://localhost:7121/api/getuser/";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(URL + email))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        user = JsonConvert.DeserializeObject<ApplicationUser>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;

                }

                return View(user);
            }




        }
    }
}

