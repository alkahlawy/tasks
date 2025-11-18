using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PersentationLayer.Contrllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiBaseController : ControllerBase
    {
        protected string GetEmailFromToken() 
            => User.FindFirstValue(ClaimTypes.Email)!;
    }
}
