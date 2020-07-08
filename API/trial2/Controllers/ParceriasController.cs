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
    [ApiController]
    [Authorize(AuthenticationSchemes = "Cookies,Bearer")]
    public class ParceriasController : ControllerBase
    {
        private readonly trial2Context _context;
        private readonly CPController _contextCP;

        public ParceriasController(trial2Context context)
        {
            _context = context;
        }

        // GET: api/Parcerias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parceria>>> GetParceria()
        {
            return await _context.Parceria.ToListAsync();
        }

        // GET: api/Parcerias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parceria>> GetParceria(int id)
        {
            var parceria = await (from us in _context.Parceria
                                  where us.identificacao == id
                                  select us).FirstOrDefaultAsync();

            if (parceria == null)
            {
                return NotFound();
            }

            return parceria;
        }



        // PUT: api/Parcerias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParceria(int id, Parceria parceria)
        {
            if (id != parceria.identificacao)
            {
                return BadRequest();
            }

            _context.Entry(parceria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParceriaExists(id))
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

        // POST: api/Parcerias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Canil_has_Parceria>> PostParceria(RecieveParceria parceria)
        {
            var parcerias = await (from p in _context.Parceria
                                   select p).ToListAsync();

            Parceria res = new Parceria();
            Canil_has_Parceria par = new Canil_has_Parceria();

            if (parcerias == null)
            {
                res.identificacao = 1;
                par.parceria_identificacao = 1;
            }
            else
            {
                res.identificacao = parcerias.Count() + 1;
                par.parceria_identificacao = res.identificacao;
            }
            par.canil_user_email = parceria.canil_user_email;

            res.nome = parceria.nome;
            res.url = parceria.url;
            res.pathLogo = parceria.pathLogo;

            _context.Parceria.Add(res);

            await _context.SaveChangesAsync();
            _context.Canil_has_Parceria.Add(par);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetParceria), new { id = res.identificacao }, res);
            //return par;
        }

        // DELETE: api/Parcerias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Parceria>> DeleteParceria(int id)
        {
            var parceria = await _context.Parceria.FindAsync(id);
            if (parceria == null)
            {
                return NotFound();
            }

            _context.Parceria.Remove(parceria);
            await _context.SaveChangesAsync();

            return parceria;
        }

        private bool ParceriaExists(int id)
        {
            return _context.Parceria.Any(e => e.identificacao == id);
        }
    }
}
