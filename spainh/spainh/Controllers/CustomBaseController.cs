using Microsoft.AspNetCore.Mvc;

namespace spainh.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
    }
}