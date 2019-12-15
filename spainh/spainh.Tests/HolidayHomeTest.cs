using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using spainh.DAL;
using spainh.DAL.Context;
using Xunit;

namespace spainh.Tests
{
    public class HolidayHomeTest
    {
        public HolidayHomeTest()
        {
            var options =
                new DbContextOptionsBuilder().UseSqlServer(
                    "Server=167.172.101.212;Database=tech_assessment;User Id=sa;Password=Regnaros210!");

            _dbcontext = new HolidayContext(options.Options);
            
            _holidayhomedal = new HolidayHomeDal(_dbcontext);
            _homeownerdal = new HomeOwnerDal(_dbcontext);
        }

        private readonly HolidayHomeDal _holidayhomedal;
        private readonly HomeOwnerDal _homeownerdal;
        private readonly HolidayContext _dbcontext;

        [Fact]
        public void CanConnect()
        {
            var connect = _dbcontext.Database.CanConnect();
            Assert.True(connect);
        }
        
        [Fact]
        public async Task GetHolidayHomesByOwnerId()
        {
            _dbcontext.Database.ExecuteSqlRaw("DELETE FROM HomeOwners;");
            _dbcontext.Database.ExecuteSqlRaw("DBCC CHECKIDENT (HomeOwners, RESEED, 0)");
            _dbcontext.Database.ExecuteSqlRaw("DELETE FROM HolidayHomes;");
            _dbcontext.Database.ExecuteSqlRaw("DBCC CHECKIDENT (HolidayHomes, RESEED, 0)");

            await _homeownerdal.AddHomeOwner(new HomeOwner {Name = "Alex Pedersen"});
            
            await _holidayhomedal.AddHolidayHome(new HolidayHome
                {Location = "Aalborg", Name = "Best Spot", Price = 500, HomeOwnerId = 1});
            await _holidayhomedal.AddHolidayHome(new HolidayHome
                {Location = "Aalborg", Name = "Best Spot", Price = 500, HomeOwnerId = 1});
            await _holidayhomedal.AddHolidayHome(new HolidayHome
                {Location = "Aalborg", Name = "Best Spot", Price = 500, HomeOwnerId = 1});
            await _holidayhomedal.AddHolidayHome(new HolidayHome
                {Location = "Aalborg", Name = "Best Spot", Price = 500, HomeOwnerId = 1});
            await _holidayhomedal.AddHolidayHome(new HolidayHome
                {Location = "Aalborg", Name = "Best Spot", Price = 500, HomeOwnerId = 1});
            await _holidayhomedal.AddHolidayHome(new HolidayHome
                {Location = "Aalborg", Name = "Best Spot", Price = 500, HomeOwnerId = 1});
            await _holidayhomedal.AddHolidayHome(new HolidayHome
                {Location = "Aalborg", Name = "Best Spot", Price = 500, HomeOwnerId = 1});
            await _holidayhomedal.AddHolidayHome(new HolidayHome
                {Location = "Aalborg", Name = "Best Spot", Price = 500, HomeOwnerId = 1});
            await _holidayhomedal.AddHolidayHome(new HolidayHome
                {Location = "Aalborg", Name = "Best Spot", Price = 500, HomeOwnerId = 1});
            await _holidayhomedal.AddHolidayHome(new HolidayHome
                {Location = "Aalborg", Name = "Best Spot", Price = 500, HomeOwnerId = 1});

            var all = await _holidayhomedal.GetHolidayHomes();
            Assert.True(all.Count.Equals(10));
            var result = await _holidayhomedal.GetHolidayHomesByOwnerId(1, 1);
            Assert.True(result.Count.Equals(5));
        }
    }
}