using Shared.DTOs.IdentityDtos;

namespace ServiceAbstractionLayer
{
    public interface IAuthenticationService
    {
        Task<UserDto> LoginAsync(LoginDto loginDto);
        Task<UserDto> RegisterAsync(RegisterDto registerDto);
        Task<bool> CheckEmailAsync(string email);
        Task<UserDto> GetCurrentUserAsync(string email);
        Task<AddressDto> GetCurrentAddressAsync(string email);
        Task<AddressDto> CreateOrUpdateAddressAsync(string email, AddressDto addressDto);
    }
}
