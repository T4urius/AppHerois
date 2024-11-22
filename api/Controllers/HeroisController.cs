using api.Data;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroisController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public HeroisController(AppDbContext dbContext) => 
            _dbContext = dbContext;

        [HttpGet]
        public async Task<List<Herois>> Get()
        {
            return await _dbContext.Herois.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Herois?> GetById(int id)
        {
            return await _dbContext.Herois.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Herois herois)
        {
            if (string.IsNullOrWhiteSpace(herois.Nome) ||
                string.IsNullOrWhiteSpace(herois.NomeHeroi) ||
                string.IsNullOrWhiteSpace(herois.Altura.ToString()) ||
                string.IsNullOrWhiteSpace(herois.Peso.ToString()))
            {
                return BadRequest("Invalid Request");
            }
            await _dbContext.Herois.AddAsync(herois);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = herois.Id }, herois);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Herois herois)
        {
            if (herois.Id == 0 ||
                string.IsNullOrWhiteSpace(herois.Nome) ||
                string.IsNullOrWhiteSpace(herois.NomeHeroi) ||
                string.IsNullOrWhiteSpace(herois.Altura.ToString()) ||
                string.IsNullOrWhiteSpace(herois.Peso.ToString()))
            {
                return BadRequest("Invalid Request");
            }

            _dbContext.Herois.Update(herois);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var herois = await GetById(id);
            if (herois == null)
            {
                return NotFound();
            }

            _dbContext.Herois.Remove(herois);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
