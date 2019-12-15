using System.Collections.Generic;
using System.Threading.Tasks;
using spainh.DAL.Context;

namespace spainh.DAL.IRepo
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