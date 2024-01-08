using Walk_and_Trails_of_SA_API.Models.Domain;

namespace Walk_and_Trails_of_SA_API.Repositories
{
    public interface IRegionRepository
    {
      Task<List<Region>> GetAllAysnc();

        Task<Region> GetAysncById(Guid id);  

        Task<Region> CreateAsync(Region region);

        Task<Region> UpdateAsync(Guid id, Region region);

        Task<Region> DeleteAsync(Guid id);
    }
}
