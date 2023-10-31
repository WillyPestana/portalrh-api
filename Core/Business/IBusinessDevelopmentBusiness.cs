using Core.Collections;
namespace Core.Business
{
    public interface IBusinessDevelopmentBusiness
    {
        #region Level Profiles
        Task<BDProfileLevelCollection> GetProfileLevelByIdAsync(string Id);
        Task<IEnumerable<BDProfileLevelCollection>> GetProfileLevelAsync();
        IEnumerable<BDProfileLevelCollection> GetProfileLevelOptions();
        Task SetProfileLevelAsync(BDProfileLevelCollection collection);
        Task UpdateProfileLevelAsync(BDProfileLevelCollection collection);
        Task DeleteProfileLevelAsync(string Id);
        Task DeleteProfileLevelLogicAsync(string Id);
        #endregion

    }
}
