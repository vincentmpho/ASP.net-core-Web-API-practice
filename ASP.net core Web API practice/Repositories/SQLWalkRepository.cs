using Microsoft.EntityFrameworkCore;
using Walk_and_Trails_of_SA_API.Data;
using Walk_and_Trails_of_SA_API.Models.Domain;

namespace Walk_and_Trails_of_SA_API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly DatabaseContext databaseContext;

        public SQLWalkRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await databaseContext.Walks.AddAsync(walk);
            await databaseContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetALLAsync()
        {
             return await databaseContext.Walks.ToListAsync();

        }
    }
}
