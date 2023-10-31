using Core.Business;
using Core.Dtos;
using Core.Services;

namespace Application.Business
{
    public class UserBusiness : IUserBusiness
    {

 
        private readonly IGraphService _graphService;

        public UserBusiness(IGraphService graphService)
        {           
            _graphService = graphService;
        }

        public async Task<List<UserDto>?> GetUsersAsync()
        {
            try
            {
                return await _graphService.GetUsersAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"UserBusiness | GetUsersAsync | {ex.Message}");
            }
        }
        public async Task<UserDto?> GetProfileAsync()
        {
            try
            {
                return await _graphService.GetProfileAsync();
            }
            catch (Exception ex)
            {

                throw new Exception($"UserBusiness | GetProfileAsync | {ex.Message}");
            }
        }

        public async Task<UserDto?> GetProfileByIdAsync(string Id)
        {
            try
            {
                return await _graphService.GetProfileByIdAsync(Id);
            }
            catch (Exception ex)
            {

                throw new Exception($"UserBusiness | GetByIdAsync | {ex.Message}");
            }
        }

        public async Task<PresenceDto?> GetPresenceAsync()
        {
            try
            {
                return await _graphService.GetPresenceAsync();
            }
            catch (Exception ex)
            {

                throw new Exception($"UserBusiness | GetPresenceAsync | {ex.Message}");
            }
        }      

    }
}