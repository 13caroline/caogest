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
    public class UtilizadorsController : ControllerBase
    {
        private readonly trial2Context _context;
        private readonly UsersController _usersController;

        public UtilizadorsController(trial2Context context)
        {
            _context = context;
            _usersController = new UsersController(context);
        }

        // GET: api/Utilizadors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilizador>>> GetUtilizador()
        {
            var utilizadores = await (from u in _context.Utilizador
                                      select u).ToListAsync();
            if (utilizadores == null)
            {
                return NotFound();
            }

            foreach (Utilizador utilizador in utilizadores)
            {
                utilizador.localidade = Encriptar.Decrypt(utilizador.localidade, "123abc");
                utilizador.rua = Encriptar.Decrypt(utilizador.rua, "1a2b3c");
                utilizador.distrito = Encriptar.Decrypt(utilizador.distrito, "cba321");
                utilizador.cc = Encriptar.Decrypt(utilizador.cc, "b32a1c");
                utilizador.nome = Encriptar.Decrypt(utilizador.nome, "1c2b3a");
            }

            return utilizadores;
        }

        // GET: api/Utilizadors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilizador>> GetUtilizador(string id)
        {
            var utilizador = await (from us in _context.Utilizador
                                    where us.email == id
                                    select us).FirstOrDefaultAsync();

            if (utilizador == null)
            {
                return NotFound();
            }

            var encriptado = await (from us in _context.User
                                    where us.email == id
                                    select us.encriptado).FirstOrDefaultAsync();

            utilizador.localidade = Encriptar.Decrypt(utilizador.localidade, "123abc");
            utilizador.rua = Encriptar.Decrypt(utilizador.rua, "1a2b3c");
            utilizador.distrito = Encriptar.Decrypt(utilizador.distrito, "cba321");
            utilizador.cc = Encriptar.Decrypt(utilizador.cc, "b32a1c");
            utilizador.nome = Encriptar.Decrypt(utilizador.nome, "1c2b3a");

            return utilizador;
        }

        // PUT: api/Utilizadors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilizador(string id, Utilizador utilizador)
        {
            if (id != utilizador.email)
            {
                return BadRequest();
            }

            utilizador.localidade = Encriptar.Encrypt(utilizador.localidade, "123abc");
            utilizador.rua = Encriptar.Encrypt(utilizador.rua, "1a2b3c");
            utilizador.distrito = Encriptar.Encrypt(utilizador.distrito, "cba321");
            utilizador.cc = Encriptar.Encrypt(utilizador.cc, "b32a1c");
            utilizador.nome = Encriptar.Encrypt(utilizador.nome, "1c2b3a");

            _context.Entry(utilizador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilizadorExists(id))
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

        // POST: api/Utilizadors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Utilizador>> PostUtilizador(ReciveUser utilizadorF)
        {

            User user = new User();

            user.email = utilizadorF.email;
            user.password = utilizadorF.password;
            user.tipo = utilizadorF.tipo;
            user.encriptado = 1;

            await _usersController.PostUser(user);

            Utilizador utilizador = new Utilizador();

            utilizador.email = utilizadorF.email;
            utilizador.nome = utilizadorF.nome;
            utilizador.data_de_nascimento = utilizadorF.data_de_nascimento;
            utilizador.distrito = utilizadorF.distrito;
            utilizador.rua = utilizadorF.rua;
            utilizador.localidade = utilizadorF.localidade;
            utilizador.cc = utilizadorF.cc;
            utilizador.sexo = utilizadorF.sexo;
            utilizador.contacto = utilizadorF.contacto;
            utilizador.favoritos = null;
            utilizador.encriptado = 1;
            utilizador.nif = utilizadorF.nif; 

            utilizador.localidade = Encriptar.Encrypt(utilizador.localidade, "123abc");
            utilizador.rua = Encriptar.Encrypt(utilizador.rua, "1a2b3c");
            utilizador.distrito = Encriptar.Encrypt(utilizador.distrito, "cba321");
            utilizador.cc = Encriptar.Encrypt(utilizador.cc, "b32a1c");
            utilizador.nome = Encriptar.Encrypt(utilizador.nome, "1c2b3a");

            _context.Utilizador.Add(utilizador);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UtilizadorExists(utilizador.email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetUtilizador), new { id = utilizador.email }, utilizador);
        }

        // DELETE: api/Utilizadors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Utilizador>> DeleteUtilizador(string id)
        {
            var utilizador = await _context.Utilizador.FindAsync(id);
            if (utilizador == null)
            {
                return NotFound();
            }

            _context.Utilizador.Remove(utilizador);
            await _context.SaveChangesAsync();

            return utilizador;
        }

        private bool UtilizadorExists(string id)
        {
            return _context.Utilizador.Any(e => e.email == id);
        }
    }
}
