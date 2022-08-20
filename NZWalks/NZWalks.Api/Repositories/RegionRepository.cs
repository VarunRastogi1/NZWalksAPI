using NZWalks.Api.Data;
using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;              //Constructor Injection
        public RegionRepository(NZWalksDbContext nZWalksDbContext)       //talk to the database to get regions

        {
            this.nZWalksDbContext = nZWalksDbContext;
        }
        public IEnumerable<Region> GetAll()
        {
            return nZWalksDbContext.Regions.ToList();
        }
    }
}
