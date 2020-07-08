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
    public class DonativosController : ControllerBase
    {
        private readonly trial2Context _context;

        public DonativosController(trial2Context context)
        {
            _context = context;
        }

        // GET: api/Donativos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donativos>>> GetDonativos()
        {
            var donativos = await _context.Donativos.ToListAsync();


            foreach (var don in donativos)
            {
                don.utilizador_user_email = await (from d in _context.Utilizador
                                                   where d.email == don.utilizador_user_email
                                                   select d.nome).FirstOrDefaultAsync();
                don.utilizador_user_email = Encriptar.Decrypt(don.utilizador_user_email, "1c2b3a");

                don.canil_user_email = await (from us in _context.Canil
                                              where us.email == don.canil_user_email
                                              select us.nome).FirstOrDefaultAsync();
                don.canil_user_email = Encriptar.Decrypt(don.canil_user_email, "bac321");
            }

            if (donativos == null)
            {
                return NotFound();
            }

            return donativos;
        }

        // GET: api/Donativos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Donativos>>> GetDonativos(string id)
        {
            var donativos = await (from d in _context.Donativos
                                   where d.canil_user_email == id
                                   select d).ToListAsync();

            foreach (var don in donativos)
            {
                don.utilizador_user_email = await (from d in _context.Utilizador
                                                   where d.email == don.utilizador_user_email
                                                   select d.nome).FirstOrDefaultAsync();
                don.utilizador_user_email = Encriptar.Decrypt(don.utilizador_user_email, "1c2b3a");

                don.canil_user_email = await (from us in _context.Canil
                                              where us.email == don.canil_user_email
                                              select us.nome).FirstOrDefaultAsync();

                don.canil_user_email = Encriptar.Decrypt(don.canil_user_email, "bac321");
            }

            if (donativos == null)
            {
                return NotFound();
            }

            return donativos;
        }

        // GET: api/Donativos/Info/5
        [HttpGet("Info/{id}")]
        //[AllowAnonymous]
        public async Task<ActionResult<ReturnDonativos2>> GetInfoDonativos(int id)
        {
            var donativo = await (from d in _context.Donativos
                                  where d.id == id
                                  select d).FirstOrDefaultAsync();

            if (donativo == null)
            {
                return NotFound();
            }

            var utilizador = await (from u in _context.Utilizador
                                    where u.email == donativo.utilizador_user_email
                                    select u).FirstOrDefaultAsync();

            if (utilizador == null)
            {
                return NotFound();
            }

            var canil = await (from c in _context.Canil
                               where c.email == donativo.canil_user_email
                               select c).FirstOrDefaultAsync();

            if (canil == null)
            {
                return NotFound();
            }

            ReturnDonativos2 res = new ReturnDonativos2();

            res.data = donativo.data;
            res.utilizador_nome = Encriptar.Decrypt(utilizador.nome, "1c2b3a");
            res.utilizador_nif = utilizador.nif;
            res.utilizador_user_email = utilizador.email;
            res.canil_user_email = canil.email;
            res.canil_nome = Encriptar.Decrypt(canil.nome, "bac321");
            res.canil_rua = Encriptar.Decrypt(canil.rua, "1a2b3c");
            res.canil_distrito = Encriptar.Decrypt(canil.distrito, "cba321");
            res.canil_localidade = Encriptar.Decrypt(canil.localidade, "123abc");
            res.canil_contacto = Encriptar.Decrypt(canil.contacto, "1c2b3a");
            res.valor = donativo.valor;
            res.descricao = donativo.descricao;

            return res;
        }

        // PUT: api/Donativos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonativos(int id, Donativos donativos)
        {
            if (id != donativos.id)
            {
                return BadRequest();
            }

            _context.Entry(donativos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonativosExists(id))
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

        // PUT: api/Donativos/Id
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("Id")]
        public async Task<ActionResult<int>> GetIDDonativos(RecieveDon donativos)
        {

            var donativo = await (from d in _context.Donativos
                                  join u in _context.Utilizador on donativos.nif equals u.nif
                                  where d.valor == Double.Parse(donativos.valor)
                                  && d.descricao == donativos.descricao
                                  && d.data.Date == DateTime.Parse(donativos.data).Date
                                  && d.canil_user_email == donativos.canil_user_email
                                  && d.utilizador_user_email == u.email
                                  select d).FirstOrDefaultAsync();

            if (donativo == null)
            {
                return BadRequest();
            }

            return donativo.id;
        }

        // POST: api/Donativos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Donativos>> PostDonativos(ReceiveDonativo donativosF)
        {
            Donativos donativos = new Donativos();
            var donativo = await (from d in _context.Donativos
                                  select d).ToListAsync();

            donativos.id = donativo.Count() + 1;

            var emailU = await (from u in _context.Utilizador
                                where u.nif == donativosF.nif
                                select u.email).FirstOrDefaultAsync();

            if (emailU == null)
            {
                return NotFound();
            }

            donativos.utilizador_user_email = emailU;
            donativos.canil_user_email = donativosF.canil_user_email;
            donativos.valor = Double.Parse(donativosF.valor);
            donativos.data = DateTime.Today;
            donativos.descricao = donativosF.descricao;

            _context.Donativos.Add(donativos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DonativosExists(donativos.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDonativos", new { id = donativos.id }, donativos);
        }

        // DELETE: api/Donativos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Donativos>> DeleteDonativos(int id)
        {
            var donativos = await _context.Donativos.FindAsync(id);
            if (donativos == null)
            {
                return NotFound();
            }

            _context.Donativos.Remove(donativos);
            await _context.SaveChangesAsync();

            return donativos;
        }

        private bool DonativosExists(int id)
        {
            return _context.Donativos.Any(e => e.id == id);
        }
    }
}
