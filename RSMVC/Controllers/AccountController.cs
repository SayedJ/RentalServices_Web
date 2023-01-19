using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RSMVC.Models;
using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace RSMVC.Controllers
{
    public class AccountController : Controller
    {
        

       
        public ViewResult Register(string returnUrl)
        {
            ApplicationUser User = new ApplicationUser();
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.PreviousUrl = HttpContext.Request.Headers["referer"];
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(ApplicationUser user, string returnUrl)
        {

            ApplicationUser receivedUser = new ApplicationUser();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:7121/api/account/register/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    receivedUser = JsonConvert.DeserializeObject<ApplicationUser>(apiResponse);
                    if (response.StatusCode == HttpStatusCode.Accepted)
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        ModelState.Clear();
                        ModelState.AddModelError(string.Empty, "");
                        return View(receivedUser);
                    }
                }


            }
            

        }
        public ViewResult Login(string returnUrl)
        {

            var user = new ApplicationUser();
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.PreviousUrl = HttpContext.Request.Headers["referer"];
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto userDto, string returnUrl)
        {
            string URL = "https://localhost:7121/api/account/login";

           
            var user = new ApplicationUser();
            var user2 = new LoginUserDto();

            using (var httpClient = new HttpClient())
            {
                
                
                StringContent content = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json");

                httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");


                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("user:user");
                string val = System.Convert.ToBase64String(plainTextBytes);

                httpClient.DefaultRequestHeaders.Add("Authorization", "basic " + val);
                //var strInng = await httpClient.GetAsync("https://localhost:7121/api/account/users/login");
                using (var response = await httpClient.PostAsync("https://localhost:7121/api/account/users/login", content))
                {
                   


                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        user = JsonConvert.DeserializeObject<ApplicationUser>(result);
                        user2.Email = user.Email;
                        user2.Password = user.Password;
                        user2.UserName = user.UserName;
               
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(ClaimTypes.Name, user.Email),
                            new Claim("UserDefined", "whatever"),
                        };

                            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var principal = new ClaimsPrincipal(identity);

                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                    principal,
                                    new AuthenticationProperties { IsPersistent = true });
                            var data = user;
                            TempData["mydata"] = JsonConvert.SerializeObject(data);

                            return Redirect(returnUrl);
                        }
                        else
                        {
                            
                            return View(user2);

                        }
                       
                    }
                    else
                    {
                        ModelState.Clear();
                        ModelState.AddModelError(string.Empty, "Username or Password is Incorrect");
                        return View("Register");
                    }




                }
                


            }


        }



        
        
    }

}