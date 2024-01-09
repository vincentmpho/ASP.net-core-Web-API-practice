using Walk_and_Trails_of_SA_API.Models.Domain;

namespace Walk_and_Trails_of_SA_API.Repositories
{
    public interface IWalkRepository
    {
          Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetALLAsync();
    }
}
