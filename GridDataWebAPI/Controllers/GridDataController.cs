using Microsoft.AspNetCore.Mvc;
using GridDataWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GridDataWebAPI.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class GridDataController : ControllerBase
    {
        public readonly GridDataContext _context;

        public GridDataController(GridDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves the latest value between the specified two datetime parameters
        /// </summary>
        /// <param name="startDate">start datetime of recorded date</param>
        /// <param name="endDate">end datetime of recorded date</param>
        /// <returns>The Latest value between start date and end date</returns>
        [HttpGet("latest-value")]
        public async Task<ActionResult<int>> GetLatestValue([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var latestValue = await _context.Measures
                                    .Where(m => m.RecordTime >= startDate && m.RecordTime <= endDate)
                                    .OrderByDescending(m => m.RecordTime)
                                    .Select(m => m.Value)
                                    .FirstOrDefaultAsync();

            return latestValue;
        }

        /// <summary>
        /// Retrieves the list of values that meets collected value parameter and between the specified two datetime parameters
        /// </summary>
        /// <param name="startDate">start datetime of recorded date</param>
        /// <param name="endDate">end datetime of recorded date</param>
        /// <param name="collectedTime">collected time</param>
        /// <returns>The list of values between start date and end date and matching collected time</returns>
        [HttpGet("collected-time")]
        public async Task<ActionResult<IEnumerable<int>>> GeteCollectedValues([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] DateTime collectedTime)
        {
            var collectedValues = await _context.Measures
                                    .Where(m => m.RecordTime >= startDate && m.RecordTime <= endDate && m.TargetTime == collectedTime)
                                    .Select(m => m.Value)
                                    .ToListAsync();

            if (collectedValues == null)
            {
                return NotFound();
            }

            return collectedValues;
        }
        

     }
    
}
