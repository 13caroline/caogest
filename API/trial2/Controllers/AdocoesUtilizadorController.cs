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
    public class AdocoesUtilizadorController : ControllerBase
    {
        private readonly trial2Context _context;

        public AdocoesUtilizadorController(trial2Context context)
        {
            _context = context;
        }

        // GET: api/AdocoesUtilizador/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ReturnAdo2>>> GetAdocao(string id)
        {
            var adocao = await (from a in _context.Adocao
                                where a.utilizador_user_email == id
                                select a).ToListAsync();

            if (adocao == null)
            {
                return NotFound();
            }

            List<ReturnAdo2> list = new List<ReturnAdo2>();

            foreach (Adocao ad in adocao)
            {
                var res = new ReturnAdo2();

                res.nPedido = ad.nPedido;
                res.data = ad.data;
                res.estado = ad.estado;
                res.cao_idCao = ad.cao_idCao;
                res.permissao = ad.permissao;
                res.alergia = ad.alergia;
                res.descAnimais = ad.descAnimais;
                res.ausencia = ad.ausencia;
                res.habitacao = ad.habitacao;
                res.exterior = ad.exterior;
                res.tipoMoradia = ad.tipoMoradia;
                res.motivo = ad.motivo;
                res.comprovativo = ad.comprovativo;
                res.donoAnimal = ad.donoAnimal;

                res.nome_Canil = await (from c in _context.Canil
                                        join ca in _context.Cao on res.cao_idCao equals ca.idCao
                                        where ca.canil_user_email == c.email
                                        select c.nome).FirstOrDefaultAsync();
                res.nome_Canil = Encriptar.Decrypt(res.nome_Canil, "bac321");

                res.nome_Cao = await (from c in _context.Cao
                                      where c.idCao == res.cao_idCao
                                      select c.nome).FirstOrDefaultAsync();

                var fotos = await (from f in _context.Fotografia
                                   where f.cao_idCao == ad.cao_idCao
                                   select f).ToListAsync();
                foreach (Fotografia f in fotos)
                {
                    res.fotos.Add(f);
                }
                list.Add(res);
            }
            return list;
        }
    }
}
