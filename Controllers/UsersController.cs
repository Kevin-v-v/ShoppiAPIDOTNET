using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppiAPIDOTNET.Data.DTOs;
using ShoppiAPIDOTNET.Data.Models;
using ShoppiAPIDOTNET.Services;
using BC = BCrypt.Net.BCrypt;


namespace ShoppiAPIDOTNET.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UsersController(UserService userService,IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserRegisterDTO userDTO)
        {
            var user = await _userService.GetUserByEmail(userDTO.Email);
            if(user != null)
            {
                return BadRequest(new {
                    errors = new { 
                        email = "El email ya está en uso"
                    }
                });
            }

            DateTime now = DateTime.Now;

            var userAccount = _mapper.Map<UserAccount>(userDTO);
            userAccount.PasswordHash = BC.HashPassword(userDTO.Password);
            userAccount.CreatedAt = now;
            userAccount.LastUpdatedAt = now;


            var userProfile = _mapper.Map<UserProfile>(userDTO);

            var result = await _userService.RegisterUser(userAccount, userProfile);
            
            return result ? Ok() : StatusCode(500);
        }

        
    }
}
