﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await nZWalksDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
            var region= await nZWalksDbContext.Regions.FirstOrDefaultAsync(x =>x.Id == id);
            return region;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await nZWalksDbContext.AddAsync(region);
            await nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region= await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id); 
            if (region == null)
            {
                return null;
            }
            //Delete the region
            nZWalksDbContext.Regions.Remove(region);
            await nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        
        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existingregion = await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingregion == null)
            {
                return null;
            }
            //Update the region
            existingregion.Code= region.Code;
            existingregion.Name = region.Name;
            existingregion.Area = region.Area;
            existingregion.Lat = region.Lat;
            existingregion.Long = region.Long;
            existingregion.Population = region.Population;
            await nZWalksDbContext.SaveChangesAsync();
            return existingregion;
        }

        
    }
}
