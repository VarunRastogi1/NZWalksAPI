using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Repositories
{
    public interface IRegionRepository
    {
        IEnumerable<Region> GetAll();
    }
}
