using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using spainh.DAL;

namespace spainh.Controllers
{
    [ApiController]
    [Route("/[controller]/[action]/{id?}")]
    public class HomeOwnerController : ControllerBase
    {
        private IHomeOwnerRepo _homeOwnerRepo;

        public HomeOwnerController(IHomeOwnerRepo homeOwnerRepo)
        {
            _homeOwnerRepo = homeOwnerRepo;
        }
        
        [HttpGet]
        [ActionName("home-owners")]
        public async Task<IActionResult> GetHomeOwners()
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
        [ActionName("home-owner")]
        public async Task<IActionResult> GetHomeOwner(int? homeOwnerId=0)
        {
            if (homeOwnerId == null)
            {
                return BadRequest();
            }

            try
            {
                var homeOwner = await _homeOwnerRepo.GetHomeOwner(homeOwnerId);
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
        [ActionName("home-owner")]
        public async Task<IActionResult> AddHomeOwner([FromBody] HomeOwner homeOwner)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var hoid = await _homeOwnerRepo.AddHomeOwner(homeOwner);
                    if (hoid > 0)
                    {
                        return Ok(hoid);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }

        [HttpDelete]
        [ActionName("home-owner")]
        public async Task<IActionResult> DeleteHomeOwner(int? homeOwnerId)
        {
            int result = 0;
            if (homeOwnerId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _homeOwnerRepo.DeleteHomeOwner(homeOwnerId);
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
        [ActionName("home-owner")]
        public async Task<IActionResult> UpdateHomeOwner([FromBody] HomeOwner homeOwner)
        {
            if (ModelState.IsValid)
            {
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

            return BadRequest();
        }
    }
}