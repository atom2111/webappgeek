using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace WebAppGeek.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CacheStatsController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public CacheStatsController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet("stats")]
        public IActionResult GetCacheStats()
        {
            var filePath = Path.Combine(_env.WebRootPath, "cache_stats.json");
            var mimeType = "application/json";
            return PhysicalFile(filePath, mimeType);
        }
    }
}
