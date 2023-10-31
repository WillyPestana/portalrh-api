using Core.Business;
using Core.Collections;
using Core.Repository;
using System.Linq.Expressions;

namespace Application.Business
{
    public class BusinessDevelopmentBusiness : IBusinessDevelopmentBusiness
    {
        private readonly IMongoRepository<BDProfileLevelCollection> _mongoRepositoryBusinessDevelopment;

        public BusinessDevelopmentBusiness(IMongoRepository<BDProfileLevelCollection> mongoRepositoryBusinessDevelopment)
        {
            _mongoRepositoryBusinessDevelopment = mongoRepositoryBusinessDevelopment;
        }

        #region Level Profiles
        public async Task<BDProfileLevelCollection> GetProfileLevelByIdAsync(string Id)
        {
            try
            {
                return await _mongoRepositoryBusinessDevelopment.FindByIdAsync(Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"BusinessDevelopmentBusiness | GetProfileLevelByIdAsync | {ex.Message}");
            }
        }

        public async Task<IEnumerable<BDProfileLevelCollection>> GetProfileLevelAsync()
        {
            try
            {
                return await _mongoRepositoryBusinessDevelopment.FilterByAsync(x => x.IsDeleted == false);
            }
            catch (Exception ex)
            {
                throw new Exception($"BusinessDevelopmentBusiness | GetProfileLevelAsync | {ex.Message}");
            }
        }

        public IEnumerable<BDProfileLevelCollection> GetProfileLevelOptions()
        {
            try
            {
                Expression<Func<BDProfileLevelCollection, bool>> filterExpression = x => x.IsDeleted == false && x.IsActive == true;
                Expression<Func<BDProfileLevelCollection, BDProfileLevelCollection>> projectionExpression = x => x;

                return  _mongoRepositoryBusinessDevelopment.FilterBy(filterExpression, projectionExpression);
            }
            catch (Exception ex)
            {
                throw new Exception($"BusinessDevelopmentBusiness | GetProfileLevelOptions | {ex.Message}");
            }
        }


        public async Task SetProfileLevelAsync(BDProfileLevelCollection collection)
        {
            try
            {
                await _mongoRepositoryBusinessDevelopment.InsertOneAsync(collection);
            }
            catch (Exception ex)
            {
                throw new Exception($"BusinessDevelopmentBusiness | SetProfileLevelAsync | {ex.Message}");
            }
        }

        public async Task UpdateProfileLevelAsync(BDProfileLevelCollection collection)
        {
            try
            {
                collection.SetUpdatedAt();
                await _mongoRepositoryBusinessDevelopment.ReplaceOneAsync(collection);
            }
            catch (Exception ex)
            {
                throw new Exception($"BusinessDevelopmentBusiness | UpdateProfileLevelAsync | {ex.Message}");
            }
        }

        public async Task DeleteProfileLevelAsync(string Id)
        {
            try
            {
                await _mongoRepositoryBusinessDevelopment.DeleteByIdAsync(Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"BusinessDevelopmentBusiness | DeleteProfileLevelAsync | {ex.Message}");
            }
        }

        public async Task DeleteProfileLevelLogicAsync(string Id)
        {
            try
            {
                BDProfileLevelCollection collection = await _mongoRepositoryBusinessDevelopment.FindByIdAsync(Id);
                collection.SetUpdatedAt();
                collection.SetDeleted();
                await _mongoRepositoryBusinessDevelopment.ReplaceOneAsync(collection);
            }
            catch (Exception ex)
            {
                throw new Exception($"BusinessDevelopmentBusiness | DeleteProfileLevelLogicAsync | {ex.Message}");
            }
        }
        #endregion

    }
}
