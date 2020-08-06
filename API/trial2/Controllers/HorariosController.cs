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
    public class HorariosController : ControllerBase
    {
        private readonly trial2Context _context;

        public HorariosController(trial2Context context)
        {
            _context = context;
        }

        private static int CompareHorariosByDay(Horario x, Horario y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {
                    if (x.dia < y.dia)
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
        }

        // GET: api/Horarios
        [HttpGet]
        public async Task<ActionResult<List<Horario>>> GetHorario()
        {
            List<Horario> horarios = await (from h in _context.Horario select h).ToListAsync();

            horarios.Sort(CompareHorariosByDay);

            return horarios;
        }

        // GET: api/Horarios/Email
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Horario>>> GetHorario(string id)
        {
            var horario = await (from us in _context.Horario
                                 where us.canil_user_email == id
                                 select us).ToListAsync();

            if (horario == null)
            {
                return NotFound();
            }

            return horario;
        }

        // PUT: api/Horarios/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHorario(DateTime id, Horario horario)
        {
            if (id != horario.dataInicio)
            {
                return BadRequest();
            }

            _context.Entry(horario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorarioExists(id))
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

        // PUT: api/Horarios/id/Dia
        [HttpPut("{id}/{dia}")]
        public async Task<IActionResult> PutHorario1(string id, int dia, ReceiveHorario horario1)
        {
            if (id != horario1.canil_user_email)
            {
                return BadRequest();
            }

            var horarioN = await (from us in _context.Horario
                                  where us.dia == dia && us.canil_user_email == id
                                  select us).FirstOrDefaultAsync();


            _context.Horario.Remove(horarioN);
            await _context.SaveChangesAsync();

            Horario horario = new Horario();
            horario.dataInicio = DateTime.Parse(horario1.dataInicio);
            horario.dataFim = DateTime.Parse(horario1.dataFim);
            horario.capacidade = Int32.Parse(horario1.capacidade);
            horario.registados = horario1.registados;
            horario.dia = horario1.dia;
            horario.canil_user_email = horario1.canil_user_email;

            _context.Horario.Add(horario);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorarioExists(horario.dataInicio))
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

        // POST: api/Horarios
        [HttpPost]
        public async Task<ActionResult<Horario>> PostHorario(Horario hora)
        {

            Horario horario = new Horario();
            horario.dataInicio = hora.dataInicio;
            horario.dataFim = hora.dataFim;
            horario.capacidade = hora.capacidade;
            horario.dia = hora.dia;
            horario.canil_user_email = hora.canil_user_email;

            _context.Horario.Add(horario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HorarioExists(horario.dataInicio))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetHorario), new { id = horario.dataInicio }, horario);
        }

        // DELETE: api/Horarios/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Horario>> DeleteHorario(DateTime id)
        {
            var horario = await _context.Horario.FindAsync(id);
            if (horario == null)
            {
                return NotFound();
            }

            _context.Horario.Remove(horario);
            await _context.SaveChangesAsync();

            return horario;
        }

        private bool HorarioExists(DateTime id)
        {
            return _context.Horario.Any(e => e.dataInicio == id);
        }
    }
}
