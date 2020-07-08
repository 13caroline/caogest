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
    public class HUController : ControllerBase
    {
        private readonly trial2Context _context;

        public HUController(trial2Context context)
        {
            _context = context;
        }

        // GET: api/HU
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Horario_has_Utilizador>>> GetHorarios_has_Utilizador()
        {
            return await _context.Horarios_has_Utilizador.ToListAsync();
        }

        // GET: api/HU/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ReturnHU>>> GetHorarios_has_Utilizador(string id)
        {
            var list = await (from us in _context.Horarios_has_Utilizador
                                                 where us.utilizador_email == id
                                                 select us).ToListAsync();

            if (list == null)
            {
                return NotFound();
            }

            var horarios_has_Utilizador = new List<ReturnHU>();

            foreach(Horario_has_Utilizador hu in list)
            {
                var res = new ReturnHU();
                res.horario_DataInicio = hu.horario_DataInicio;
                res.horario_DataFim = hu.horario_DataFim;
                res.horario_Dia = hu.horario_Dia;
                res.horario_Canil_User_Email = hu.horario_Canil_User_Email;
                res.utilizador_email = hu.utilizador_email;

                var nome = await (from c in _context.Canil
                                  where c.email == hu.horario_Canil_User_Email
                                  select c.nome).FirstOrDefaultAsync();
                res.nome_canil = Encriptar.Decrypt(nome, "bac321");

                horarios_has_Utilizador.Add(res);
            }

            return horarios_has_Utilizador;
        }

        // GET: api/HU/5/2/1
        [HttpGet("{id1}/{id2}/{id3}")]
        public async Task<ActionResult<List<Horario_has_Utilizador>>> GetHorarios_has_Utilizador(string id1, string id2, string id3)
        {
            var horarios_has_Utilizador = await (from us in _context.Horarios_has_Utilizador
                                                 where us.utilizador_email == id1 && us.horario_Dia == Int32.Parse(id2) && us.horario_Canil_User_Email == id3
                                                 select us).ToListAsync();

            if (horarios_has_Utilizador == null)
            {
                return NotFound();
            }

            return horarios_has_Utilizador;
        }

        // PUT: api/HU/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHorarios_has_Utilizador(DateTime id, Horario_has_Utilizador horarios_has_Utilizador)
        {
            if (id != horarios_has_Utilizador.horario_DataInicio)
            {
                return BadRequest();
            }

            _context.Entry(horarios_has_Utilizador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Horarios_has_UtilizadorExists(id))
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

        // POST: api/HU
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Horario_has_Utilizador>> PostHorarios_has_Utilizador(Horario_has_Utilizador horarios_has_Utilizador)
        {
            _context.Horarios_has_Utilizador.Add(horarios_has_Utilizador);

            var horario = await (from h in _context.Horario
                                 where h.dia == horarios_has_Utilizador.horario_Dia && h.canil_user_email == horarios_has_Utilizador.horario_Canil_User_Email
                                 select h).FirstOrDefaultAsync();
            horario.registados++;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Horarios_has_UtilizadorExists(horarios_has_Utilizador.horario_DataInicio))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHorarios_has_Utilizador", new { id = horarios_has_Utilizador.horario_DataInicio }, horarios_has_Utilizador);
        }

        // DELETE: api/HU/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Horario_has_Utilizador>> DeleteHorarios_has_Utilizador(DateTime id)
        {
            var horarios_has_Utilizador = await _context.Horarios_has_Utilizador.FindAsync(id);
            if (horarios_has_Utilizador == null)
            {
                return NotFound();
            }

            _context.Horarios_has_Utilizador.Remove(horarios_has_Utilizador);
            await _context.SaveChangesAsync();

            return horarios_has_Utilizador;
        }

        private bool Horarios_has_UtilizadorExists(DateTime id)
        {
            return _context.Horarios_has_Utilizador.Any(e => e.horario_DataInicio == id);
        }
    }
}
