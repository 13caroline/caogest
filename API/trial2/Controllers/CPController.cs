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
    public class CPController : ControllerBase
    {
        private readonly trial2Context _context;

        public CPController(trial2Context context)
        {
            _context = context;
        }

        // GET: api/CP
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parceria>>> GetCanil_has_Parceria()
        {
            return await _context.Parceria.ToListAsync();
        }

        // GET: api/CP/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Parceria>>> GetCanil_has_Parceria(string id)
        {
            var canil_has_Parceria = await (from us in _context.Canil_has_Parceria
                                            join c in _context.Parceria on us.parceria_identificacao equals c.identificacao
                                            where us.canil_user_email == id
                                            select c).ToListAsync();

            if (canil_has_Parceria == null)
            {
                return NotFound();
            }

            return canil_has_Parceria;
        }

        // PUT: api/CP/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCanil_has_Parceria(string id, Canil_has_Parceria canil_has_Parceria)
        {
            if (id != canil_has_Parceria.canil_user_email)
            {
                return BadRequest();
            }

            _context.Entry(canil_has_Parceria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Canil_has_ParceriaExists(id))
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

        // POST: api/CP
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Canil_has_Parceria>> PostCanil_has_Parceria(Canil_has_Parceria canil_has_Parceria)
        {
            _context.Canil_has_Parceria.Add(canil_has_Parceria);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Canil_has_ParceriaExists(canil_has_Parceria.canil_user_email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCanil_has_Parceria", new { id = canil_has_Parceria.canil_user_email }, canil_has_Parceria);
        }

        // DELETE: api/CP/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Canil_has_Parceria>> DeleteCanil_has_Parceria(string id)
        {
            var canil_has_Parceria = await _context.Canil_has_Parceria.FindAsync(id);
            if (canil_has_Parceria == null)
            {
                return NotFound();
            }

            _context.Canil_has_Parceria.Remove(canil_has_Parceria);
            await _context.SaveChangesAsync();

            return canil_has_Parceria;
        }

        private bool Canil_has_ParceriaExists(string id)
        {
            return _context.Canil_has_Parceria.Any(e => e.canil_user_email == id);
        }
    }
}
