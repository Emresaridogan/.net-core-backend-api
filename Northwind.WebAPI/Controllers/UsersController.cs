using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Business.Abstract;
using Northwind.Business.Constants;
using Northwind.Core.Entities.Concrete;

namespace Northwind.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getusers")]
        public IActionResult GetUsers()
        {
            var result = _userService.GetUsers();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getuserbyemail")]
        public IActionResult GetUserByMail(string email)
        {
            var result = _userService.GetUserByMail(email);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(Messages.UserNotFound);
        }

        [HttpGet("getclaimsbyid")]
        public IActionResult GetClaimsById(User user)
        {
            var result = _userService.GetOperationClaims(user);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Hata");
        }

        [HttpGet("getclaims")]
        public IActionResult GetClaims()
        {
            var result = _userService.GetOperationClaims();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Hata");
        }

        [HttpPost("adduser")]
        public IActionResult AddUser(User user)
        {
            var result = _userService.AddUser(user);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("updateuser")]
        public IActionResult UpdateUser(User user)
        {
            var result = _userService.UpdateUser(user);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("deleteuser")]
        public IActionResult DeleteUser(User user)
        {
            var result = _userService.DeleteUser(user);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

    }
}
