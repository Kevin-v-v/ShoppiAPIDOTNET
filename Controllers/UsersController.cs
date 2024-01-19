using Microsoft.AspNetCore.Mvc;
using ShoppiAPIDOTNET.Data.DTOs;

namespace ShoppiAPIDOTNET.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {

        public UsersController()
        {
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponseDTO>> Register(UserCredentialsDTO userCredentials)
        {
            return new AuthResponseDTO();
        }

        
    }
}
