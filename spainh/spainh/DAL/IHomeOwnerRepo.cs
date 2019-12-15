using System.Collections.Generic;
using System.Threading.Tasks;

namespace spainh.DAL
{
    public interface IHomeOwnerRepo
    {
        Task<List<HomeOwner>> GetHomeOwners();
        Task<HomeOwner> GetHomeOwner(int? homeOwnerId);
        Task<int> AddHomeOwner(HomeOwner homeOwner);
        Task<int> DeleteHomeOwner(int? homeOwnerId);
        Task UpdateHomeOwner(HomeOwner homeOwner);
    }
}