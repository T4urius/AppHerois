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
        public async Task<ActionResult<Herois>> Create([FromBody] Herois herois)
        {
            if (string.IsNullOrWhiteSpace(herois.Nome) ||
                string.IsNullOrWhiteSpace(herois.NomeHeroi) ||
                string.IsNullOrWhiteSpace(herois.Altura.ToString()) ||
                string.IsNullOrWhiteSpace(herois.Peso.ToString()))
            {
                return BadRequest("Invalid Request");
            }

            var heroisSuperpoderes = new Herois_Superpoderes() { SuperpoderId = herois.Idsuperpoder.GetValueOrDefault(), HeroiId = herois.Id };

            await _dbContext.HeroisSuperPoderes.AddAsync(heroisSuperpoderes);
            await _dbContext.Herois.AddAsync(herois);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = herois.Id }, herois);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Herois>> Update(int id, Herois herois)
        {
            if (id != herois.Id)
            {
                return BadRequest("Invalid Request");
            }

            _dbContext.Herois.Update(herois);
            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.Herois.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_dbContext.Herois == null)
            {
                return NotFound();
            }
            var paymentDetail = await _dbContext.Herois.FindAsync(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            _dbContext.Herois.Remove(paymentDetail);
            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.Herois.ToListAsync());
        }
    }
}
