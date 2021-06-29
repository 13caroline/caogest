using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trial2.Models;

namespace trial2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        private readonly trial2Context _context;

        public TesteController(trial2Context context)
        {
            _context = context;
        }

        // POST: api/Teste
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<String>> PostAdocao(IFormFile file)
        {
            using (var stream = System.IO.File.Create("/Users/carolina/Desktop/LI/caogest/src/assets/" + file.FileName))
            {
                await file.CopyToAsync(stream);
            }
            return "Complete";
        }
    }
}
