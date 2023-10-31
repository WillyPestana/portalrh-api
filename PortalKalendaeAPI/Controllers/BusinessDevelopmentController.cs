using AutoMapper;
using Core.Business;
using Core.Collections;
using Core.Dtos;
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
    public class BusinessDevelopmentController : ControllerBase
    {

        private readonly IBusinessDevelopmentBusiness _businessDevelopmentBusiness;
        private readonly IMapper _mapper;

        public BusinessDevelopmentController(
            IBusinessDevelopmentBusiness businessDevelopmentBusiness,
            IMapper mapper)
        {
            _businessDevelopmentBusiness = businessDevelopmentBusiness;
            _mapper = mapper;
        }

        #region Level Profiles

        [HttpGet("ProfileLevel/{Id}")]
        [EnableQuery]
        public async Task<IActionResult> GetProfileLevelByIdAsync(string Id)
        {
            try
            {
                return Ok(_mapper.Map<BDProfileLevelDto>(await _businessDevelopmentBusiness.GetProfileLevelByIdAsync(Id)));
            }
            catch (Exception ex)
            {
                throw new Exception($"BusinessDevelopmentController | GetProfileLevelByIdAsync | {ex.Message}");
            }
        }

        [HttpGet("ProfileLevel")]
        [EnableQuery]
        public async Task<IActionResult> GetProfileLevelAsync()
        {
            try
            {
                return Ok(_mapper.Map<List<BDProfileLevelDto>>(await _businessDevelopmentBusiness.GetProfileLevelAsync()));
            }
            catch (Exception ex)
            {
                throw new Exception($"BusinessDevelopmentController | GetProfileLevelAsync | {ex.Message}");
            }
        }

        [HttpGet("ProfileLevelOptions")]
        [EnableQuery]
        public IActionResult GetProfileLevelOptions()
        {
            try
            {
                return Ok(_mapper.Map<List<BDProfileLevelOptionsDto>>(_businessDevelopmentBusiness.GetProfileLevelOptions()));
            }
            catch (Exception ex)
            {
                throw new Exception($"BusinessDevelopmentController | GetProfileLevelOptions| {ex.Message}");
            }
        }

        [HttpPost("ProfileLevel")]
        public async Task<IActionResult> SetProfileLevelAsync([FromBody] BDProfileLevelInsertDto model)
        {
            try
            {
                await _businessDevelopmentBusiness.SetProfileLevelAsync(_mapper.Map<BDProfileLevelCollection>(model));
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception($"UserController | SetProfileLevelAsync | {ex.Message}");
            }
        }

        [HttpPut("ProfileLevel")]
        public async Task<IActionResult> UpdateProfileLevelAsync([FromBody] BDProfileLevelUpdateDto model)
        {
            try
            {
                await _businessDevelopmentBusiness.UpdateProfileLevelAsync(_mapper.Map<BDProfileLevelCollection>(model));
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception($"UserController | UpdateProfileLevelAsync | {ex.Message}");
            }
        }

        [HttpDelete("ProfileLevel/{Id}")]
        public async Task<IActionResult> DeleteProfileLevelAsync(string Id)
        {
            try
            {
                await _businessDevelopmentBusiness.DeleteProfileLevelAsync(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception($"UserController | DeleteProfileLevelAsync | {ex.Message}");
            }
        }

        [HttpDelete("ProfileLevelLogic/{Id}")]
        public async Task<IActionResult> DeleteProfileLevelLogicAsync(string Id)
        {
            try
            {
                await _businessDevelopmentBusiness.DeleteProfileLevelLogicAsync(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception($"UserController | DeleteProfileLevelLogicAsync | {ex.Message}");
            }
        }

        #endregion


    }
}
