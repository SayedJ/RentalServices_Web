using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalServicesWebApi.Configuratioins;
using RentalServicesWebApi.Models;
using RentalServicesWebApi.Repository;

namespace RentalServicesWebApi.Controllers
{
    [ApiController]
    [Route("api/")]
    public class UserController : ControllerBase
    {
        
        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }
        public BasicAuthenticationHandler handler;


        private readonly IUnitOfWork _unitOfWork;
            private readonly IWebHostEnvironment webHostEnvironment;

            private readonly UserManager<ApplicationUser> _userManager;
            private readonly SignInManager<ApplicationUser> _signInManager;
            private readonly ILogger<AccountController> _logger;
            private readonly IMapper _mapper;
            private readonly IConfiguration _configuration;


            public UserController(UserManager<ApplicationUser> userManager,

                ILogger<AccountController> logger,
                IMapper mapper,
                IUnitOfWork unitOfWork,
                IWebHostEnvironment environment,
                SignInManager<ApplicationUser> signInManager,
                IConfiguration configuration

                )
            {
                _userManager = userManager;

                _logger = logger;
                _mapper = mapper;
                _unitOfWork = unitOfWork;
                webHostEnvironment = environment;
                _signInManager = signInManager;
                _configuration = configuration;
            }


            [Authorize(AuthenticationSchemes = "BasicAuthentication")]
            [HttpGet]
            [Route("users")]
            public async Task<IEnumerable<ApplicationUser>> AllUsers()
            {
                   
            try
                {
                
                    var users =  _userManager.Users.ToListAsync();
                    return await users;

                }


                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Something Went Wrong in the {nameof(AllUsers)}");
                return (IEnumerable<ApplicationUser>)Unauthorized();

                }

            }

            [HttpGet]
            [Route("getuser/{email=unnamed}")]
            public ActionResult<ApplicationUser> GetUser(string email)
            {
                try
                {
                    if (string.IsNullOrEmpty(email))
                        return BadRequest("Value must be passed in the request body.");
                    var user = _userManager.Users.FirstOrDefault(s => s.Email == email);

                    return Ok(user);

                }


                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Something Went Wrong in the {nameof(AllUsers)}");
                    return Problem($"Something Went Wrong in the {nameof(AllUsers)}", statusCode: 500);

                }

            }





           

        }



    }

