using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission10_Shaw.Data;
using SQLitePCL;

namespace Mission10_Shaw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlersController : ControllerBase
    {
        private BowlingLeagueContext _context;

        public BowlersController(BowlingLeagueContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetBowlers")]
        public IEnumerable<Bowler> Get()
        {
            var bowlerList = _context.Bowlers
                                     .Include(b => b.Team)  // Eagerly load the related Team data
                                     .ToList();

            return bowlerList;
        }


        // Get all bowlers
        //        [HttpGet]
        //        public async Task<ActionResult<IEnumerable<Bowler>>> GetBowlers()
        //        {
        //            return await _context.Bowlers.ToListAsync();
        //        }

        //        // Get bowlers from a specific team
        //        [HttpGet("team/{teamName}")]
        //        public async Task<ActionResult<IEnumerable<Bowler>>> GetBowlersByTeam(string teamName)
        //        {
        //            var bowlers = await _context.Bowlers.Where(b => b.Team == teamName).ToListAsync();
        //            if (bowlers == null || bowlers.Count == 0)
        //            {
        //                return NotFound();
        //            }
        //            return bowlers;
        //        }

    }

}
