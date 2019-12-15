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
    public class HomeOwnersController : ControllerBase
    {
        private IHomeOwnerRepo _homeOwnerRepo;

        public HomeOwnersController(IHomeOwnerRepo homeOwnerRepo)
        {
            _homeOwnerRepo = homeOwnerRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var homeowners = await _homeOwnerRepo.GetHomeOwners();
                if (homeowners != null)
                {
                    return Ok(homeowners);
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
                var homeOwner = await _homeOwnerRepo.GetHomeOwner(id);
                if (homeOwner == null)
                {
                    return NotFound();
                }

                return Ok(homeOwner);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HomeOwner homeOwner)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var homeownerid = await _homeOwnerRepo.AddHomeOwner(homeOwner);
                if (homeownerid > 0)
                {
                    return Ok(homeownerid);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            int result = 0;

            try
            {
                result = await _homeOwnerRepo.DeleteHomeOwner(id);
                if (result == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] HomeOwner homeOwner)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                await _homeOwnerRepo.UpdateHomeOwner(homeOwner);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}