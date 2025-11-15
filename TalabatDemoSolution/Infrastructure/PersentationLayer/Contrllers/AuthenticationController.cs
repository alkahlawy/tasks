using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstractionLayer;
using Shared.DTOs.IdentityDtos;
using System.Security.Claims;

namespace PersentationLayer.Contrllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AuthenticationController(IServiceManager _serviceManager) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _serviceManager.AuthenticationService.LoginAsync(loginDto);
            return Ok(user);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var user = await _serviceManager.AuthenticationService.RegisterAsync(registerDto);
            return Ok(user);
        }

        [HttpGet("CheckEmail")]
        public async Task<ActionResult<bool>> CheckEmail(string email)
        {
            var res = await _serviceManager.AuthenticationService.GetCurrentAddressAsync(email);
            return Ok(res);
        }

        [Authorize]
        [HttpGet("CurrentEmail")]
        public async Task<ActionResult<UserDto>> GetCurrentEmail()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var appUser = await _serviceManager.AuthenticationService.GetCurrentUserAsync(email!);
            return Ok(appUser);
        }

        [Authorize]
        [HttpGet("CurrentAddress")]
        public async Task<ActionResult<AddressDto>> GetCurrentAddress()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var userAddress = await _serviceManager.AuthenticationService.GetCurrentAddressAsync(email!);
            return Ok(userAddress);
        }

        [Authorize]
        [HttpGet("UpdateAddress")]
        public async Task<ActionResult<AddressDto>> UpdateCurrentAddress(AddressDto addressDto)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var updatedAddress = await _serviceManager.AuthenticationService.CreateOrUpdateAddressAsync(email!, addressDto);
            return Ok(updatedAddress);
        }


    }
}
