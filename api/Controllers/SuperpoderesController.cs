using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperpoderesController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public SuperpoderesController(AppDbContext dbContext) => 
            _dbContext = dbContext;

        [HttpGet]
        public async Task<List<Superpoderes>> Get()
        {
            return await _dbContext.Superpoderes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Superpoderes?> GetById(int id)
        {
            return await _dbContext.Superpoderes.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<Superpoderes>> Create([FromBody] Superpoderes superpoderes)
        {
            if (string.IsNullOrWhiteSpace(superpoderes.Superpoder) ||
                string.IsNullOrWhiteSpace(superpoderes.Descricao))
            {
                return BadRequest("Invalid Request");
            }
            await _dbContext.Superpoderes.AddAsync(superpoderes);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = superpoderes.Id }, superpoderes);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Superpoderes>> Update(int id, Superpoderes superpoderes)
        {
            if (id != superpoderes.Id)
            {
                return BadRequest("Invalid Request");
            }

            _dbContext.Superpoderes.Update(superpoderes);
            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.Superpoderes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_dbContext.Superpoderes == null)
            {
                return NotFound();
            }
            var paymentDetail = await _dbContext.Superpoderes.FindAsync(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            _dbContext.Superpoderes.Remove(paymentDetail);
            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.Superpoderes.ToListAsync());
        }
    }
}
