using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using spainh.DAL.Context;
using spainh.DAL.IRepo;

namespace spainh.Controllers
{
    [ApiController]
    [Route("/[controller]/[action]")]
    [Produces("application/json")]
    public class HolidayHomesController : ControllerBase
    {
        private IHolidayHomeRepo _holidayHomeRepo;

        public HolidayHomesController(IHolidayHomeRepo holidayHomeRepo)
        {
            _holidayHomeRepo = holidayHomeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var holidayhomes = await _holidayHomeRepo.GetHolidayHomes();
                if (holidayhomes != null)
                {
                    return Ok(holidayhomes);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                var holidayHome = await _holidayHomeRepo.GetHolidayHome(id);
                if (holidayHome == null)
                {
                    return NotFound();
                }

                return Ok(holidayHome);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetHolidayHomesHomeOwnerId(int id, int page)
        {
            try
            {
                var holidayhomes = await _holidayHomeRepo.GetHolidayHomesByOwnerId(id, page);
                if (holidayhomes == null)
                {
                    return NotFound();
                }

                return Ok(holidayhomes);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HolidayHome holidayHome)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var holidayhomeid = await _holidayHomeRepo.AddHolidayHome(holidayHome);
                if (holidayhomeid > 0)
                {
                    return Ok(holidayhomeid);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            int result = 0;

            try
            {
                result = await _holidayHomeRepo.DeleteHolidayHome(id);
                if (result == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] HolidayHome holidayHome)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                await _holidayHomeRepo.UpdateHolidayHome(holidayHome);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}