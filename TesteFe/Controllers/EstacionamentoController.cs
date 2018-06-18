using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteFe.Models;

namespace TesteFe.Controllers
{
    [Produces("application/json")]
    [Route("api/Estacionamento")]
    public class EstacionamentoController : Controller
    {
        private readonly EstacionamentoContext _context;

        public EstacionamentoController(EstacionamentoContext context)
        {
            _context = context;
        }

        // GET: api/Estacionamento
        [HttpGet]
        public IEnumerable<Estacionamento> GetEstacionamento()
        {
            return _context.Estacionamento;
        }

        // GET: api/Estacionamento/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstacionamento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estacionamento = await _context.Estacionamento.SingleOrDefaultAsync(m => m.EstacionamentoID == id);

            if (estacionamento == null)
            {
                return NotFound();
            }

            return Ok(estacionamento);
        }

        // PUT: api/Estacionamento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstacionamento([FromRoute] int id, [FromBody] Estacionamento estacionamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estacionamento.EstacionamentoID)
            {
                return BadRequest();
            }

            _context.Entry(estacionamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstacionamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Estacionamento
        [HttpPost]
        public async Task<IActionResult> PostEstacionamento([FromBody] Estacionamento estacionamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Estacionamento.Add(estacionamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstacionamento", new { id = estacionamento.EstacionamentoID }, estacionamento);
        }

        // DELETE: api/Estacionamento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstacionamento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estacionamento = await _context.Estacionamento.SingleOrDefaultAsync(m => m.EstacionamentoID == id);
            if (estacionamento == null)
            {
                return NotFound();
            }

            _context.Estacionamento.Remove(estacionamento);
            await _context.SaveChangesAsync();

            return Ok(estacionamento);
        }

        private bool EstacionamentoExists(int id)
        {
            return _context.Estacionamento.Any(e => e.EstacionamentoID == id);
        }
    }
}