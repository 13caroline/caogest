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
    public class FavoritosController : ControllerBase
    {
        private readonly trial2Context _context;

        public FavoritosController(trial2Context context)
        {
            _context = context;
        }

        // GET: api/Favoritos
        [HttpGet]
        public async Task<ActionResult<List<ReturnFavoritos>>> GetFavoritos()
        {
            List<ReturnFavoritos> result = new List<ReturnFavoritos>();
            var favoritos = await (from us in _context.Favoritos
                                   join c in _context.Cao on us.cao_idCa equals c.idCao
                                   select c).ToListAsync();

            if (favoritos == null)
            {
                return NotFound();
            }

            foreach (Cao cao in favoritos)
            {
                ReturnFavoritos res = new ReturnFavoritos();

                res.idCao = cao.idCao;
                res.nome = cao.nome;
                res.sexo = cao.sexo;
                res.descricao = cao.descricao;
                res.estado = cao.estado;
                res.raca = cao.raca;
                res.cor = cao.cor;
                res.idade = cao.idade;
                res.esterilizacao = cao.esterilizacao;
                res.porte = cao.porte;
                res.email_canil = cao.canil_user_email;
                var nomeC = await (from f in _context.Canil
                                   where f.email == cao.canil_user_email
                                   select f.nome).FirstOrDefaultAsync();
                res.nome_canil = Encriptar.Decrypt(nomeC, "bac321");
                var fotos = await (from f in _context.Fotografia
                                   where f.cao_idCao == cao.idCao
                                   select f).ToListAsync();

                foreach (Fotografia f in fotos)
                {
                    res.fotos.Add(f);
                }

                result.Add(res);
            }
            return result;
        }

        // GET: api/Favoritos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ReturnFavoritos>>> GetFavoritos(string id)
        {
            List<ReturnFavoritos> result = new List<ReturnFavoritos>();
            var favoritos = await (from us in _context.Favoritos
                                   join c in _context.Cao on us.cao_idCa equals c.idCao
                                   where us.utilizador_user_email == id
                                   select c).ToListAsync();

            if (favoritos == null)
            {
                return NotFound();
            }

            foreach (Cao cao in favoritos)
            {
                ReturnFavoritos res = new ReturnFavoritos();

                res.idCao = cao.idCao;
                res.nome = cao.nome;
                res.sexo = cao.sexo;
                res.descricao = cao.descricao;
                res.estado = cao.estado;
                res.raca = cao.raca;
                res.cor = cao.cor;
                res.idade = cao.idade;
                res.esterilizacao = cao.esterilizacao;
                res.porte = cao.porte;
                res.email_canil = cao.canil_user_email;
                var nomeC = await (from f in _context.Canil
                                   where f.email == cao.canil_user_email
                                   select f.nome).FirstOrDefaultAsync();
                res.nome_canil = Encriptar.Decrypt(nomeC, "bac321");
                var fotos = await (from f in _context.Fotografia
                                   where f.cao_idCao == cao.idCao
                                   select f).ToListAsync();

                foreach (Fotografia f in fotos)
                {
                    res.fotos.Add(f);
                }

                result.Add(res);
            }
            return result;
        }

        // PUT: api/Favoritos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoritos(string id, Favoritos favoritos)
        {
            if (id != favoritos.utilizador_user_email)
            {
                return BadRequest();
            }

            _context.Entry(favoritos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoritosExists(id, favoritos.cao_idCa))
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

        // POST: api/Favoritos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Favoritos>> PostFavoritos(Favoritos favoritos)
        {
            _context.Favoritos.Add(favoritos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FavoritosExists(favoritos.utilizador_user_email, favoritos.cao_idCa))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFavoritos", new { id = favoritos.utilizador_user_email }, favoritos);
        }

        // DELETE: api/Favoritos/5
        [HttpDelete("{id1}/{id2}")]
        public async Task<ActionResult<Favoritos>> DeleteFavoritos(string id1, int id2)
        {
            var favoritos = await (from f in _context.Favoritos
                                   where f.utilizador_user_email == id1 && f.cao_idCa == id2
                                   select f).FirstOrDefaultAsync();
            if (favoritos == null)
            {
                return NotFound();
            }

            _context.Favoritos.Remove(favoritos);
            await _context.SaveChangesAsync();

            return favoritos;
        }

        private bool FavoritosExists(string id1, int id2)
        {
            return _context.Favoritos.Any(e => e.utilizador_user_email == id1 && e.cao_idCa == id2);
        }
    }
}
