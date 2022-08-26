using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Repositories
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllAsync();
    }
}
