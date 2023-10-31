using Core.Dtos;

namespace Core.Business
{
    public interface IUserBusiness
    {
        Task<List<UserDto>?> GetUsersAsync();
        Task<UserDto?> GetProfileAsync();
        Task<UserDto?> GetProfileByIdAsync(string Id);
        Task<PresenceDto?> GetPresenceAsync();      
    }
}
