using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace spainh.DAL.Context
{
    public class HolidayContext : DbContext
    {
        public HolidayContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<HolidayHome>? HolidayHomes { get; set; }
        public DbSet<HomeOwner>? HomeOwners { get; set; }
    }

    public class HomeOwner
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        private ICollection<HolidayHome>? Holidayhomes { get; set; }
    }

    public class HolidayHome
    {
        [Key] public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public int? Price { get; set; }
        public HomeOwner? HomeOwner { get; set; }
        [ForeignKey("HomeOwner")] public int HomeOwnerId { get; set; }
    }
}