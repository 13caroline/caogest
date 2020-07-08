using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trial2.Models;
using trial2.Results;

namespace trial2.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class ComprovativosController : ControllerBase
    {
        private readonly trial2Context _context;

        public ComprovativosController(trial2Context context)
        {
            _context = context;
        }

        // GET: api/Comprovativos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comprovativo>>> GetComprovativo()
        {
            return await _context.Comprovativo.ToListAsync();
        }

        // GET: api/Comprovativos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comprovativo>> GetComprovativo(int id)
        {
            var comprovativo = await (from c in _context.Comprovativo
                                      where c.adocao_NPedido == id
                                      select c).FirstOrDefaultAsync();

            if (comprovativo == null)
            {
                return NotFound();
            }

            return comprovativo;
        }

        // PUT: api/Comprovativos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComprovativo(int id, Comprovativo comprovativo)
        {
            if (id != comprovativo.idComprovativo)
            {
                return BadRequest();
            }

            _context.Entry(comprovativo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComprovativoExists(id))
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

        // POST: api/Comprovativos/tmp@trial.com
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{mail}")]
        public async Task<ActionResult<List<Adocao>>> PostComprovativo(string mail, IFormFile file)
        {
            var adocoes = await (from a in _context.Adocao
                                 where a.utilizador_user_email == mail
                                 select a).ToListAsync();

            if (adocoes == null)
            {
                return BadRequest();
            }

            var comprovativos = await (from c in _context.Comprovativo
                                       select c).ToListAsync();

            Comprovativo comprovativo = new Comprovativo();

            if (comprovativos == null)
            {
                comprovativo.idComprovativo = 1;
            }
            else comprovativo.idComprovativo = comprovativos.Count() + 1;

            comprovativo.path = file.FileName;

            using (var stream = System.IO.File.Create("/Users/carolina/Desktop/LI/caogest/public/images/" + file.FileName))
            {
                await file.CopyToAsync(stream);
            }

            comprovativo.adocao_NPedido = adocoes[adocoes.Count() - 1].nPedido;

            _context.Comprovativo.Add(comprovativo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComprovativo), new { id = comprovativo.idComprovativo }, comprovativo);
        }

        // DELETE: api/Comprovativos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comprovativo>> DeleteComprovativo(int id)
        {
            var comprovativo = await _context.Comprovativo.FindAsync(id);
            if (comprovativo == null)
            {
                return NotFound();
            }

            _context.Comprovativo.Remove(comprovativo);
            await _context.SaveChangesAsync();

            return comprovativo;
        }

        private bool ComprovativoExists(int id)
        {
            return _context.Comprovativo.Any(e => e.idComprovativo == id);
        }
    }
}
