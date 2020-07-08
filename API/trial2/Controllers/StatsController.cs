using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using trial2.Models;

namespace trial2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Cookies,Bearer")]
    public class StatsController : ControllerBase
    {
        private readonly trial2Context _context;

        public StatsController(trial2Context context)
        {
            _context = context;
        }

        // GET: api/Stats/Users
        [HttpGet("Users")]
        public async Task<ActionResult<int>> GetStatsU()
        {
            var users = await (from u in _context.User
                               select u).ToListAsync();
            if (users == null)
            {
                return NotFound();
            }

            int count = users.Count();

            return count;
        }

        // GET: api/Stats/Voluntarios
        [HttpGet("Voluntarios")]
        public async Task<ActionResult<int>> GetStatsV()
        {
            var users = await (from v in _context.Voluntarios
                               select v).ToListAsync();
            if (users == null)
            {
                return NotFound();
            }

            int count = users.Count();

            return count;
        }

        // GET: api/Stats/Caes
        [HttpGet("Caes")]
        public async Task<ActionResult<int>> GetStatsC()
        {
            var users = await (from c in _context.Cao
                               select c).ToListAsync();
            if (users == null)
            {
                return NotFound();
            }

            int count = users.Count();

            return count;
        }

        // GET: api/Stats/Adocoes
        [HttpGet("Adocoes")]
        public async Task<ActionResult<int>> GetStatsA()
        {
            var users = await (from a in _context.Adocao
                               where a.estado == "Aceite"
                               select a).ToListAsync();
            if (users == null)
            {
                return NotFound();
            }

            int count = users.Count();

            return count;
        }

        // GET: api/Stats/Pedidos/Mes
        [HttpGet("Pedidos/Mes")]
        public async Task<ActionResult<List<int>>> GetStatsPM()
        {
            var users = await (from a in _context.Adocao
                               where a.estado == "Aceite"
                               select a).ToListAsync();
            
            if (users == null)
            {
                return NotFound();
            }

            List<int> valores = new List<int>();
            
            for(int i=0; i< 12; i++) valores.Add(0);

            foreach(Adocao a in users)
            {
                if (a.data.Month == 1) valores[0]++;
                else if (a.data.Month == 2) valores[1]++;
                else if (a.data.Month == 3) valores[2]++;
                else if (a.data.Month == 4) valores[3]++;
                else if (a.data.Month == 5) valores[4]++;
                else if (a.data.Month == 6) valores[5]++;
                else if (a.data.Month == 7) valores[6]++;
                else if (a.data.Month == 8) valores[7]++;
                else if (a.data.Month == 9) valores[8]++;
                else if (a.data.Month == 10) valores[9]++;
                else if (a.data.Month == 11) valores[10]++;
                else valores[11]++;
            }

            return valores;
        }

        // GET: api/Stats/Pedidos/Cao
        [HttpGet("Pedidos/Cao")]
        public async Task<ActionResult<List<int>>> GetStatsPC()
        {
            var pequenos = await (from a in _context.Adocao
                                  join c in _context.Cao on a.cao_idCao equals c.idCao
                                  where a.estado == "Aceite" && c.porte == "Pequeno"
                                  select a).ToListAsync();

            var medios = await (from a in _context.Adocao
                                  join c in _context.Cao on a.cao_idCao equals c.idCao
                                  where a.estado == "Aceite" && c.porte == "Medio"
                                  select a).ToListAsync();
            
            var grandes = await (from a in _context.Adocao
                                  join c in _context.Cao on a.cao_idCao equals c.idCao
                                  where a.estado == "Aceite" && c.porte == "Grande"
                                  select a).ToListAsync();

            if (pequenos == null || medios == null || grandes == null)
            {
                return NotFound();
            }
            
            List<int> valores = new List<int>();

            valores.Add(pequenos.Count());
            valores.Add(medios.Count());
            valores.Add(grandes.Count());

            return valores;
        }

        // GET: api/Stats/Pedidos/Donativos
        [HttpGet("Pedidos/Donativos")]
        public async Task<ActionResult<List<int>>> GetStatsD()
        {
            var donativos = await (from d in _context.Donativos
                               select d).ToListAsync();

            if (donativos == null)
            {
                return NotFound();
            }

            List<int> valores = new List<int>();

            for (int i = 0; i < 12; i++) valores.Add(0);

            foreach (Donativos d in donativos)
            {
                if (d.data.Month == 1) valores[0]++;
                else if (d.data.Month == 2) valores[1]++;
                else if (d.data.Month == 3) valores[2]++;
                else if (d.data.Month == 4) valores[3]++;
                else if (d.data.Month == 5) valores[4]++;
                else if (d.data.Month == 6) valores[5]++;
                else if (d.data.Month == 7) valores[6]++;
                else if (d.data.Month == 8) valores[7]++;
                else if (d.data.Month == 9) valores[8]++;
                else if (d.data.Month == 10) valores[9]++;
                else if (d.data.Month == 11) valores[10]++;
                else valores[11]++;
            }

            return valores;
        }

        // GET: api/Stats/Estado
        [HttpGet("Estado")]
        public async Task<ActionResult<List<int>>> GetStatsCE()
        {
            var aceites = await (from a in _context.Canil
                                  where a.estado == "Aceite"
                                  select a).ToListAsync();

            var pendente = await (from a in _context.Canil
                                where a.estado == "Pendente"
                                select a).ToListAsync();

            var recusado = await (from a in _context.Canil
                                 where a.estado == "Rejeitado"
                                 select a).ToListAsync();

            if (aceites == null || pendente == null || recusado == null)
            {
                return NotFound();
            }

            List<int> valores = new List<int>();

            valores.Add(aceites.Count());
            valores.Add(pendente.Count());
            valores.Add(recusado.Count());

            return valores;
        }

        // GET: api/Stats/Donativos
        [HttpGet("Donativos")]
        public async Task<ActionResult<List<List<int>>>> GetStatsDA()
        {
            var donativos = await (from a in _context.Donativos
                                 select a).ToListAsync();

            if (donativos == null)
            {
                return NotFound();
            }

            List<List<int>> donativosF = new List<List<int>>();
            
            List<int> valores1 = new List<int>();
            for (int i = 0; i < 12; i++) valores1.Add(0);
            List<int> valores2 = new List<int>();
            for (int i = 0; i < 12; i++) valores2.Add(0);
            List<int> valores3 = new List<int>();
            for (int i = 0; i < 12; i++) valores3.Add(0);

            foreach (Donativos d in donativos)
            {
                if(d.data.Year == 2020)
                {
                    if (d.data.Month == 1) valores1[0]++;
                    else if (d.data.Month == 2) valores1[1]++;
                    else if (d.data.Month == 3) valores1[2]++;
                    else if (d.data.Month == 4) valores1[3]++;
                    else if (d.data.Month == 5) valores1[4]++;
                    else if (d.data.Month == 6) valores1[5]++;
                    else if (d.data.Month == 7) valores1[6]++;
                    else if (d.data.Month == 8) valores1[7]++;
                    else if (d.data.Month == 9) valores1[8]++;
                    else if (d.data.Month == 10) valores1[9]++;
                    else if (d.data.Month == 11) valores1[10]++;
                    else valores1[11]++;
                }
                else if (d.data.Year == 2019)
                {
                    if (d.data.Month == 1) valores2[0]++;
                    else if (d.data.Month == 2) valores2[1]++;
                    else if (d.data.Month == 3) valores2[2]++;
                    else if (d.data.Month == 4) valores2[3]++;
                    else if (d.data.Month == 5) valores2[4]++;
                    else if (d.data.Month == 6) valores2[5]++;
                    else if (d.data.Month == 7) valores2[6]++;
                    else if (d.data.Month == 8) valores2[7]++;
                    else if (d.data.Month == 9) valores2[8]++;
                    else if (d.data.Month == 10) valores2[9]++;
                    else if (d.data.Month == 11) valores2[10]++;
                    else valores2[11]++;
                }
                else
                {
                    if (d.data.Month == 1) valores3[0]++;
                    else if (d.data.Month == 2) valores3[1]++;
                    else if (d.data.Month == 3) valores3[2]++;
                    else if (d.data.Month == 4) valores3[3]++;
                    else if (d.data.Month == 5) valores3[4]++;
                    else if (d.data.Month == 6) valores3[5]++;
                    else if (d.data.Month == 7) valores3[6]++;
                    else if (d.data.Month == 8) valores3[7]++;
                    else if (d.data.Month == 9) valores3[8]++;
                    else if (d.data.Month == 10) valores3[9]++;
                    else if (d.data.Month == 11) valores3[10]++;
                    else valores3[11]++;
                }

            }
            
            donativosF.Add(valores1);
            donativosF.Add(valores2);
            donativosF.Add(valores3);

            return donativosF;
        }
    }
}
