using Microsoft.AspNetCore.Identity;

namespace Demo.DAL.Models.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        // Add any additional properties you want for your application user here
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
    }
}
