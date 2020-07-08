using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trial2.Models;

namespace trial2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Cookies,Bearer")]
    public class SugestoesController : ControllerBase
    {
        private readonly trial2Context _context;

        public SugestoesController(trial2Context context)
        {
            _context = context;
        }

        // GET: api/Sugestoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sugestoes>>> GetSugestoes()
        {
            return await _context.Sugestoes.ToListAsync();
        }

        // GET: api/Sugestoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sugestoes>> GetSugestoes(int id)
        {
            var sugestoes = await (from s in _context.Sugestoes
                                   where s.identificacao == id
                                   select s).SingleOrDefaultAsync();

            if (sugestoes == null)
            {
                return NotFound();
            }

            return sugestoes;
        }

        // GET: api/Sugestoes/Users/trial@example.com
        [HttpGet("Users/{id}")]
        public async Task<ActionResult<List<Sugestoes>>> GetSugestoes(string id)
        {
            var sugestoes = await (from s in _context.Sugestoes
                                   where s.user_email == id
                                   select s).ToListAsync();

            if (sugestoes == null)
            {
                return NotFound();
            }

            return sugestoes;
        }

        // PUT: api/Sugestoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSugestoes(int id, Sugestoes sugestoes)
        {
            if (id != sugestoes.identificacao)
            {
                return BadRequest();
            }

            _context.Entry(sugestoes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SugestoesExists(id))
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

        // POST: api/Sugestoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sugestoes>> PostSugestoes(Sugestoes sugestoes)
        {
            var list = await (from s in _context.Sugestoes
                              select s).ToListAsync();
            if (list == null)
            {
                return NotFound();
            }

            sugestoes.identificacao = list.Count() + 1;

            _context.Sugestoes.Add(sugestoes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSugestoes", new { id = sugestoes.identificacao }, sugestoes);
        }

        // DELETE: api/Sugestoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sugestoes>> DeleteSugestoes(int id)
        {
            var sugestoes = await _context.Sugestoes.FindAsync(id);
            if (sugestoes == null)
            {
                return NotFound();
            }

            _context.Sugestoes.Remove(sugestoes);
            await _context.SaveChangesAsync();

            return sugestoes;
        }

        private bool SugestoesExists(int id)
        {
            return _context.Sugestoes.Any(e => e.identificacao == id);
        }
    }
}
