using Microsoft.AspNetCore.Mvc;
using WolfnetAPI.Data;
using WolfnetAPI.Models;

namespace WolfnetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly MatchDbContext _context;

        private readonly ILogger<MatchController> _logger;

        public MatchController(MatchDbContext context, ILogger<MatchController> logger)
        {
            _context = context; 
            _logger = logger;
        }

        [HttpPost(Name = "AddMatch")]
        public async Task<IActionResult> Add(int id, int number)
        {
            try
            {
                var match = new Match { 
                                        Id = id,
                                        Number = number
                                      };

                await _context.Matches.AddAsync(match);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Match successfully added.");

                return CreatedAtAction(nameof(GetMatchById), new { id = match.Id }, match);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding match.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("{id}", Name = "GetMatchById")]
        public async Task<IActionResult> GetMatchById(int id)
        {
            var match = await _context.Matches.FindAsync(id);

            if (match == null)
            {
                return NotFound("Match not found.");
            }

            return Ok(match);
        }

        [HttpDelete("{id}", Name = "DeleteMatch")]
        public async Task<IAction>
    }
}
