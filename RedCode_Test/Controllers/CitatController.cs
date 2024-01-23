using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedCode_Test.Data;
using RedCode_Test.Models;

namespace RedCode_Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitatController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CitatController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Book>>> GetAll()
        {
            return Ok(await _dbContext.Citats.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostHero(Citat citat)
        {
            _dbContext.Citats.Add(citat);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Citats.ToListAsync());
        }

        [HttpDelete]
        [Route("{id}")]
        //[Route("Delete/{id:int}")]
        public async Task<ActionResult<Citat>> Delete(int id)
        {
            var citat = await _dbContext.Citats.FindAsync(id);

            if (citat == null)
            {
                return BadRequest("Citat not found");
            }

            _dbContext.Citats.Remove(citat);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Citats.ToListAsync());
        }
    }
}
