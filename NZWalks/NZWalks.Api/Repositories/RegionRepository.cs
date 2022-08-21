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
    }
}
