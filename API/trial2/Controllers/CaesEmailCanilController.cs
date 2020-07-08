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
    public class CaesEmailCanilController : ControllerBase
    {
        private readonly trial2Context _context;

        public CaesEmailCanilController(trial2Context context)
        {
            _context = context;
        }

        // GET: api/CaesEmailCanil/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ReturnCao>>> GetCao(string id)
        {
            var caes = await (from ca in _context.Cao
                              where ca.canil_user_email == id
                              select ca).ToListAsync();

            if (caes == null)
            {
                return NotFound();
            }


            var fotos = await (from f in _context.Fotografia
                               select f).ToListAsync();
            if (fotos == null)
            {
                return NotFound();
            }

            List<ReturnCao> list = new List<ReturnCao>();
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
                foreach (Fotografia f in fotos)
                {
                    if (f.cao_idCao == cao.idCao) res.fotos.Add(f);
                }
                list.Add(res);
            }
            return list;
        }
    }
}