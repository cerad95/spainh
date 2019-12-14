using System;
using Microsoft.AspNetCore.Mvc;

namespace spainh.Controllers
{
    public class Home : CustomBaseController
    {
        // GET
        public IActionResult Index()
        {
            return Ok($"Test {DateTime.UtcNow}");
        }
    }
}