using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace spainh.DAL
{
    public class HomeOwnerDal : IHomeOwnerRepo
    {
        private HolidayContext db;

        public HomeOwnerDal(HolidayContext _db)
        {
            db = _db;
        }
        public async Task<List<HomeOwner>> GetHomeOwners()
        {
            if (db == null) return null;
            try
            {
                return await db.HomeOwners.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<HomeOwner> GetHomeOwner(int? homeOwnerId)
        {
            if (db == null) return null;
            try
            {
                return await db.HomeOwners.FirstOrDefaultAsync(x => x.Id.Equals(homeOwnerId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<int> AddHomeOwner(HomeOwner homeOwner)
        {
            if (db == null) return 0;
            await db.HomeOwners.AddAsync(homeOwner);
            await db.SaveChangesAsync();
            return homeOwner.Id;
        }

        public async Task<int> DeleteHomeOwner(int? homeOwnerId)
        {
            var result = 0;
            if (db == null) return result;
            var homeowner = await db.HomeOwners.FirstOrDefaultAsync(x => x.Id == homeOwnerId);
            if (homeowner == null) return result;
            db.HomeOwners.Remove(homeowner);
            result = await db.SaveChangesAsync();
            return result;
        }

        public async Task UpdateHomeOwner(HomeOwner homeOwner)
        {
            if (db != null)
            {
                db.HomeOwners.Update(homeOwner);
                await db.SaveChangesAsync();
            }
        }
    }
}