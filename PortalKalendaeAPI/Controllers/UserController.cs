using Core.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.Identity.Web.Resource;

namespace PortalKalendaeAPI.Controllers
{
    [Authorize("Bearer")]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetUsersAsync()
        {
            try
            {
                return Ok(await _userBusiness.GetUsersAsync());
            }
            catch (Exception ex)
            {
                throw new Exception($"UserController | GetUsersAsync | {ex.Message}");
            }
        }

        [HttpGet("Profile")]
        [EnableQuery]
        public async Task<IActionResult> GetProfileAsync()
        {
            try
            {
                return Ok(await _userBusiness.GetProfileAsync());
            }
            catch (Exception ex)
            {
                throw new Exception($"UserController | GetProfileAsync | {ex.Message}");
            }
        }

        [HttpGet("ProfileById/{Id}")]
        [EnableQuery]
        public async Task<IActionResult> GetProfileByIdAsync(string Id)
        {
            try
            {
                return Ok(await _userBusiness.GetProfileByIdAsync(Id));
            }
            catch (Exception ex)
            {
                throw new Exception($"UserController | GetProfileByIdAsync | {ex.Message}");
            }
        }

        [HttpGet("Presence")]
        [EnableQuery]
        public async Task<IActionResult> GetUserPresenceAsync()
        {
            try
            {
                return Ok(await _userBusiness.GetPresenceAsync());
            }
            catch (Exception ex)
            {
                throw new Exception($"UserController | GetUserPresenceAsync | {ex.Message}");
            }
        }
    
    }
}
