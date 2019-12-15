using System.Collections.Generic;
using System.Threading.Tasks;
using spainh.DAL.Context;

namespace spainh.DAL.IRepo
{
    public interface IHolidayHomeRepo
    {
        Task<List<HolidayHome>> GetHolidayHomes();
        Task<HolidayHome> GetHolidayHome(int? id);
        Task<int> AddHolidayHome(HolidayHome homeOwner);
        Task<int> DeleteHolidayHome(int? id);
        Task UpdateHolidayHome(HolidayHome homeOwner);
        Task<List<HolidayHome>> GetHolidayHomesByOwnerId(int id, int page);
    }
}