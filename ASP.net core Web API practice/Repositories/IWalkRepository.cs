using Walk_and_Trails_of_SA_API.Models.Domain;

namespace Walk_and_Trails_of_SA_API.Repositories
{
    public interface IWalkRepository
    {
          Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetALLAsync();
       Task<Walk?> GetByIdAsync(Guid id);

        Task<Walk?> UpdateByIdAsync(Guid id, Walk walk);

        Task<Walk?> DeleteAsync(Guid id);
    }
}
