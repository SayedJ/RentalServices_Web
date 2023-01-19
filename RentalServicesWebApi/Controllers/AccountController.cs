using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RentalServicesWebApi.Dto;
using RentalServicesWebApi.Models;
using RentalServicesWebApi.Repository;

namespace RentalServicesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment webHostEnvironment;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;


        public AccountController(UserManager<ApplicationUser> userManager,
            
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



        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {

            _logger.LogInformation($"Registration attempt for {userDto.Email}");
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = _mapper.Map<ApplicationUser>(userDto);
                if (string.IsNullOrEmpty(userDto.Roles.First())){
                    userDto.Roles.Add("user");
                }
                var result = await _userManager.CreateAsync(user, userDto.Password);

               
                if(!result.Succeeded)
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                await _userManager.AddToRolesAsync(user, userDto.Roles);
                return Accepted(); 

            }
            catch ( Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");
                return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500);
            }
        }

        [HttpGet]
        [Route("users")]
        [Authorize]
        public ActionResult<List<ApplicationUser>> AllUsers()
        {

            
            try
            {
                var users = _userManager.Users.ToList();
                return Ok(users);
               
            }
            

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(AllUsers)}");
                return Problem($"Something Went Wrong in the {nameof(AllUsers)}", statusCode: 500);

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




        [Authorize(AuthenticationSchemes = "BasicAuthentication")]
        [HttpPost]
        [Route("users/login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto userDto)
        {

            
                var user = await _userManager.FindByEmailAsync(userDto.Email);
                var usersine = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (user != null && await _userManager.CheckPasswordAsync(user, userDto.Password))
                {
                var userRoles = await _userManager.GetRolesAsync(user);
                try
                {
                    var SingleUser = _userManager.Users.SingleOrDefault(x => x.Email == userDto.Email);

                    var verfiyPassword = _userManager.PasswordHasher.VerifyHashedPassword(SingleUser, SingleUser.PasswordHash, userDto.Password);
                    if (verfiyPassword != PasswordVerificationResult.Success)
                    {


                        return Unauthorized(userDto);
                    }

                    //If the verification success.
                    if (verfiyPassword == PasswordVerificationResult.Success)
                    {
                        var isthis = _signInManager.SignInAsync(SingleUser, true);
                        var usersines = User.FindFirstValue(ClaimTypes.NameIdentifier);
                        var istrue = Microsoft.AspNetCore.Identity.SignInResult.Success;
                        var whatis = isthis;
                        Console.WriteLine("Right");
                        return Ok(SingleUser);
                    }
                }


                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Something Went Wrong in the {nameof(Login)}");
                    Console.WriteLine("something is not right");
                    return Problem($"Something Went Wrong in the {nameof(Login)}", statusCode: 500);

                }

                }
            Console.WriteLine("something is not right");
            return Unauthorized(";asdfjlasdf aunthoaswris aizksdif ");
        }

       

    }



}

