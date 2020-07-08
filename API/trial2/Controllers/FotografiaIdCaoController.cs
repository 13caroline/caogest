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
    public class FotografiaIdCaoController : ControllerBase
    {
        private readonly trial2Context _context;

        public FotografiaIdCaoController(trial2Context context)
        {
            _context = context;
        }

        // GET: api/Fotografias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Fotografia>>> GetFotografia(int id)
        {
            var fotografia = await (from f in _context.Fotografia
                                    where f.cao_idCao == id
                                    select f).ToListAsync(); ;

            if (fotografia == null)
            {
                return NotFound();
            }

            return fotografia;
        }
    }
}