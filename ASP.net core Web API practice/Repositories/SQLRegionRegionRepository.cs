using Microsoft.EntityFrameworkCore;
using Walk_and_Trails_of_SA_API.Data;
using Walk_and_Trails_of_SA_API.Models.Domain;

namespace Walk_and_Trails_of_SA_API.Repositories
{
    public class SQLRegionRegionRepository : IRegionRepository
    {
        private readonly DatabaseContext databaseContext;
        public SQLRegionRegionRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await databaseContext.AddAsync(region);
            await databaseContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var existingRegion = await databaseContext.Regions.FirstOrDefaultAsync(x=> x.Id==id);
            if (existingRegion != null)
            {
                return null;
            }
             databaseContext.Regions.Remove(existingRegion);
            await databaseContext.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<List<Region>> GetAllAysnc()
        {
             return await databaseContext.Regions.ToListAsync();   
        }

        public async Task<Region> GetAysncById(Guid id)
        {
           return await databaseContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }
         
        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await databaseContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRegion != null)
            {
                existingRegion.Code = region.Code;
                existingRegion.Name = region.Name;
                existingRegion.RegionImageUrl = region.RegionImageUrl;

                await databaseContext.SaveChangesAsync();
            }

            return existingRegion; // Return updated region or null if not found
        }


    }
}
