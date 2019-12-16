using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using spainh.DAL.Context;
using spainh.DAL.IRepo;

namespace spainh.DAL
{
    public class HolidayHomeDal : IHolidayHomeRepo
    {
        private readonly HolidayContext _db;

        public HolidayHomeDal(HolidayContext db)
        {
            _db = db;
        }

        public async Task<List<HolidayHome>> GetHolidayHomes()
        {
            if (_db == null) return null;
            try
            {
                return await _db.HolidayHomes.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<HolidayHome> GetHolidayHome(int id)
        {
            if (_db == null) return null;
            try
            {
                return await _db.HolidayHomes.FirstOrDefaultAsync(x => x.Id.Equals(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<int> AddHolidayHome(HolidayHome holidayHome)
        {
            if (_db == null) return 0;
            await _db.HolidayHomes.AddAsync(holidayHome);
            await _db.SaveChangesAsync();
            return holidayHome.Id;
        }

        public async Task<int> DeleteHolidayHome(int id)
        {
            var result = 0;
            if (_db == null) return result;
            var holidayHome = await _db.HolidayHomes.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (holidayHome == null) return result;
            _db.HolidayHomes.Remove(holidayHome);
            result = await _db.SaveChangesAsync();
            return result;
        }

        public async Task UpdateHolidayHome(HolidayHome holidayHome)
        {
            if (_db != null)
            {
                _db.HolidayHomes.Update(holidayHome);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<HolidayHome>> GetHolidayHomesByOwnerId(int id, int page)
        {
            if (_db == null) return null;
            try
            {
                return await _db.HolidayHomes.Where(x => x.HomeOwnerId.Equals(id)).Skip(5 * page).Take(5).Include(x => x.HomeOwner).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}