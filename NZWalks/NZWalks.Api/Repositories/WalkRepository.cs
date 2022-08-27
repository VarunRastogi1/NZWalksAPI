using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data;
using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public WalkRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }
        
        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await nZWalksDbContext.Walks
                .Include(x => x.Region)                             //Adding Navigation properties for GetAllWalks
                .Include(x=> x.WalkDifficulty)
                .ToListAsync();
        }

        public Task<Walk> GetAsync(Guid id)
        {
            return nZWalksDbContext.Walks
                .Include(x => x.Region)                             //Adding Navigation properties for GetWalks
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync(x=>x.Id==id);
                
        }
    }
}
