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
    public class VoluntariosController : ControllerBase
    {
        private readonly trial2Context _context;

        public VoluntariosController(trial2Context context)
        {
            _context = context;
        }

        // GET: api/Voluntarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnVoluntario>>> GetVoluntarios()
        {
            var voluntarios = await _context.Voluntarios.ToListAsync();

            List<ReturnVoluntario> vol = new List<ReturnVoluntario>();

            foreach (var v in voluntarios)
            {
                var res = new ReturnVoluntario();

                res.nomeCanil = await (from d in _context.Canil
                                       where d.email == v.canil_user_email
                                       select d.nome).FirstOrDefaultAsync();
                res.nomeCanil = Encriptar.Decrypt(res.nomeCanil, "bac321");

                res.nomeUser = await (from d in _context.Utilizador
                                      where d.email == v.utilizador_user_email
                                      select d.nome).FirstOrDefaultAsync();
                res.nomeUser = Encriptar.Decrypt(res.nomeUser, "1c2b3a");

                res.mailUser = v.utilizador_user_email;

                res.contacto = await (from d in _context.Utilizador
                                      where d.email == v.utilizador_user_email
                                      select d.contacto).FirstOrDefaultAsync();

                res.sexo = await (from d in _context.Utilizador
                                  where d.email == v.utilizador_user_email
                                  select d.sexo).FirstOrDefaultAsync();

                res.data_de_nascimento = await (from d in _context.Utilizador
                                                where d.email == v.utilizador_user_email
                                                select d.data_de_nascimento).FirstOrDefaultAsync();

                vol.Add(res);
            }

            if (voluntarios == null)
            {
                return NotFound();
            }

            return vol;
        }

        // GET: api/Voluntarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ReturnVoluntario>>> GetVoluntarios(string id)
        {
            var voluntarios = await (from us in _context.Voluntarios
                                     where us.canil_user_email == id
                                     select us).ToListAsync();

            List<ReturnVoluntario> vol = new List<ReturnVoluntario>();

            foreach (var v in voluntarios)
            {
                var res = new ReturnVoluntario();

                res.nomeCanil = await (from d in _context.Canil
                                       where d.email == v.canil_user_email
                                       select d.nome).FirstOrDefaultAsync();
                res.nomeCanil = Encriptar.Decrypt(res.nomeCanil, "bac321");

                res.nomeUser = await (from d in _context.Utilizador
                                      where d.email == v.utilizador_user_email
                                      select d.nome).FirstOrDefaultAsync();
                res.nomeUser = Encriptar.Decrypt(res.nomeUser, "1c2b3a");

                res.mailUser = v.utilizador_user_email;

                res.contacto = await (from d in _context.Utilizador
                                      where d.email == v.utilizador_user_email
                                      select d.contacto).FirstOrDefaultAsync();

                res.sexo = await (from d in _context.Utilizador
                                  where d.email == v.utilizador_user_email
                                  select d.sexo).FirstOrDefaultAsync();

                res.data_de_nascimento = await (from d in _context.Utilizador
                                                where d.email == v.utilizador_user_email
                                                select d.data_de_nascimento).FirstOrDefaultAsync();

                vol.Add(res);
            }

            if (voluntarios == null)
            {
                return NotFound();
            }

            return vol;

        }

        // GET: api/Voluntarios/Utilizador/5
        [HttpGet("Utilizador/{id}")]
        public async Task<ActionResult<List<ReturnVoluntario>>> GetVoluntariosU(string id)
        {
            var voluntarios = await (from us in _context.Voluntarios
                                     where us.utilizador_user_email == id
                                     select us).ToListAsync();

            List<ReturnVoluntario> vol = new List<ReturnVoluntario>();

            foreach (var v in voluntarios)
            {
                var res = new ReturnVoluntario();

                Canil canil = await (from d in _context.Canil
                                     where d.email == v.canil_user_email
                                     select d).FirstOrDefaultAsync();

                res.nomeCanil = Encriptar.Decrypt(canil.nome, "bac321");

                res.mailUser = v.canil_user_email;

                res.contacto = Encriptar.Decrypt(canil.contacto, "1c2b3a");

                res.localidade = Encriptar.Decrypt(canil.localidade, "123abc");

                vol.Add(res);
            }

            if (voluntarios == null)
            {
                return NotFound();
            }

            return vol;

        }

        // PUT: api/Voluntarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoluntarios(string id, Voluntarios voluntarios)
        {
            if (id != voluntarios.canil_user_email)
            {
                return BadRequest();
            }

            _context.Entry(voluntarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoluntariosExists(id))
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

        // POST: api/Voluntarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Voluntarios>> PostVoluntarios(Voluntarios voluntarios)
        {
            _context.Voluntarios.Add(voluntarios);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VoluntariosExists(voluntarios.canil_user_email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVoluntarios", new { id = voluntarios.canil_user_email }, voluntarios);
        }

        // DELETE: api/Voluntarios/5/3
        [HttpDelete("{id1}/{id2}")]
        public async Task<ActionResult<Voluntarios>> DeleteVoluntarios(string id1, string id2)
        {
            var voluntarios = await (from v in _context.Voluntarios
                                     where v.canil_user_email == id1 && v.utilizador_user_email == id2
                                     select v).FirstOrDefaultAsync();
            if (voluntarios == null)
            {
                return NotFound();
            }

            _context.Voluntarios.Remove(voluntarios);
            await _context.SaveChangesAsync();

            return voluntarios;
        }

        private bool VoluntariosExists(string id)
        {
            return _context.Voluntarios.Any(e => e.canil_user_email == id);
        }
    }
}
