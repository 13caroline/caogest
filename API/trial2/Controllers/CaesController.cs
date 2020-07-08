using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using trial2.Models;
using trial2.Results;

namespace trial2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Cookies,Bearer")]
    public class CaesController : ControllerBase
    {
        private readonly trial2Context _context;
        private readonly FotografiasController _contextFoto;

        public CaesController(trial2Context context)
        {
            _context = context;
            _contextFoto = new FotografiasController(context);
        }

        // GET: api/Caes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnCao>>> GetCao()
        {
            List<ReturnCao> result = new List<ReturnCao>();

            var caes = await _context.Cao.ToListAsync();

            foreach (Cao cao in caes)
            {
                ReturnCao res = new ReturnCao();

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
                var canil = await (from f in _context.Canil
                                   where f.email == cao.canil_user_email
                                   select f).FirstOrDefaultAsync();

                res.nome_canil = Encriptar.Decrypt(canil.nome, "bac321");
                res.distrito = Encriptar.Decrypt(canil.distrito, "cba321");
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

        // GET: api/Caes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnCao>> GetCao(int id)
        {
            var cao = await (from ca in _context.Cao
                             where ca.idCao == id
                             select ca).FirstOrDefaultAsync();

            if (cao == null)
            {
                return NotFound();
            }

            var fotos = await (from f in _context.Fotografia
                               where f.cao_idCao == id
                               select f).ToListAsync();

            ReturnCao res = new ReturnCao();

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
            var nome = await (from f in _context.Canil
                              where f.email == cao.canil_user_email
                              select f.nome).FirstOrDefaultAsync();
            res.nome_canil = Encriptar.Decrypt(nome, "bac321");
            foreach (Fotografia f in fotos)
            {
                res.fotos.Add(f);
            }

            return res;
        }

        // PUT: api/Caes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCao(int id, Cao cao)
        {
            if (id != cao.idCao)
            {
                return BadRequest();
            }

            _context.Entry(cao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaoExists(id))
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

        // PUT: api/Caes/Adocao/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("Adocao/{id}")]
        public async Task<IActionResult> PutCaoEsp(int id, Cao caoEs)
        {
            var cao = await (from c in _context.Cao
                             where c.idCao == id
                             select c).FirstOrDefaultAsync();

            if (cao == null)
            {
                return NotFound();
            }

            cao.estado = caoEs.estado;

            _context.Entry(cao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaoExists(id))
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

        // PUT: api/Caes/Update/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutCaoEsp1(int id, RecieveCao caoEs)
        {
            var cao = await (from c in _context.Cao
                             where c.idCao == id
                             select c).FirstOrDefaultAsync();

            if (cao == null)
            {
                return NotFound();
            }

            cao.idade = Int32.Parse(caoEs.idade);
            cao.esterilizacao = caoEs.esterilizacao;

            _context.Entry(cao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaoExists(id))
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

        // POST: api/Caes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cao>> PostCao(RecieveCao cao)
        {
            var caes = await (from c in _context.Cao
                              select c).ToListAsync();

            Cao res = new Cao();

            if (caes == null)
            {
                res.idCao = 1;
            }
            else
            {
                res.idCao = caes.Count() + 1;
            }

            res.nome = cao.nome;
            res.sexo = cao.sexo;
            res.descricao = cao.descricao;
            res.estado = cao.estado;
            res.raca = cao.raca;
            res.idade = Int32.Parse(cao.idade);
            res.esterilizacao = cao.esterilizacao;
            res.porte = cao.porte;
            res.canil_user_email = cao.canil_user_email;
            res.cor = cao.cor[0];
            for (int i = 1; i < cao.cor.Count(); i++)
            {
                res.cor = res.cor + ", " + cao.cor[i];
            }
            var canil = await (from c in _context.Canil
                               where c.email == cao.canil_user_email
                               select c).FirstOrDefaultAsync();
            canil.capacidadeOcupada++;
            _context.Cao.Add(res);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCao), new { id = res.idCao }, res);
        }

        // DELETE: api/Caes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cao>> DeleteCao(int id)
        {
            var cao = await _context.Cao.FindAsync(id);
            if (cao == null)
            {
                return NotFound();
            }

            _context.Cao.Remove(cao);
            await _context.SaveChangesAsync();

            return cao;
        }

        private bool CaoExists(int id)
        {
            return _context.Cao.Any(e => e.idCao == id);
        }
    }
}
