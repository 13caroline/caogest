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
        [HttpPost]
        public async Task<ActionResult<String>> PostAdocao(IFormFile file)
        {
            using (var stream = System.IO.File.Create(/* PATH */ + file.FileName))
            {
                await file.CopyToAsync(stream);
            }
            return "Complete";
        }
    }
}
