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
using MailKit.Net.Smtp;
//using MailKit;
using MimeKit;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using MailKit.Security;
using System.Net.Mail;
using System.Net.Mime;

namespace trial2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Cookies,Bearer")]
    public class CanisController : ControllerBase
    {
        private readonly trial2Context _context;
        private readonly UsersController _usersController;
        private readonly HorariosController _horariosController;

        public CanisController(trial2Context context)
        {
            _context = context;
            _usersController = new UsersController(context);
            _horariosController = new HorariosController(context);
        }

        // GET: api/Canis
        [HttpGet]
        public async Task<ActionResult<List<Canil>>> GetCanil()
        {
            var canis = await (from c in _context.Canil
                               select c).ToListAsync();
            if (canis == null)
            {
                return NotFound();
            }

            foreach (Canil c in canis)
            {
                c.localidade = Encriptar.Decrypt(c.localidade, "123abc");
                c.rua = Encriptar.Decrypt(c.rua, "1a2b3c");
                c.distrito = Encriptar.Decrypt(c.distrito, "cba321");
                c.nib = Encriptar.Decrypt(c.nib, "b32a1c");
                c.nome = Encriptar.Decrypt(c.nome, "bac321");
                c.contacto = Encriptar.Decrypt(c.contacto, "1c2b3a");
            }

            return canis;
        }

        // GET: api/Canis/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ReturnCanil>> GetCanil(string id)
        {
            var canil = await (from c in _context.Canil
                               where c.email == id
                               select c).FirstOrDefaultAsync();

            if (canil == null)
            {
                return NotFound();
            }

            canil.localidade = Encriptar.Decrypt(canil.localidade, "123abc");
            canil.rua = Encriptar.Decrypt(canil.rua, "1a2b3c");
            canil.distrito = Encriptar.Decrypt(canil.distrito, "cba321");
            canil.nib = Encriptar.Decrypt(canil.nib, "b32a1c");
            canil.nome = Encriptar.Decrypt(canil.nome, "bac321");
            canil.contacto = Encriptar.Decrypt(canil.contacto, "1c2b3a");

            var horario = await (from h in _context.Horario
                                 where h.canil_user_email == canil.email
                                 select h).ToListAsync();

            ReturnCanil res = new ReturnCanil();

            res.email = canil.email;
            res.nib = canil.nib;
            res.nome = canil.nome;
            res.capacidadeOcupada = canil.capacidadeOcupada;
            res.capacidadeTotal = canil.capacidadeTotal;
            res.distrito = canil.distrito;
            res.rua = canil.rua;
            res.localidade = canil.localidade;
            res.contacto = canil.contacto;
            res.estado = canil.estado;

            foreach (Horario h in horario)
            {
                res.horarios.Add(h);
            }


            return res;
        }

        // PUT: api/Canis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCanil(string id, RecieveCanil1 canilF)
        {
            if (id != canilF.email)
            {
                return BadRequest();
            }

            var canil = await (from c in _context.Canil
                               where c.email == id
                               select c).FirstOrDefaultAsync();

            canil.capacidadeOcupada = canilF.capacidadeOcupada;
            canil.capacidadeTotal = canilF.capacidadeTotal;
            canil.encriptado = 1;

            canil.localidade = Encriptar.Encrypt(canilF.localidade, "123abc");
            canil.rua = Encriptar.Encrypt(canilF.rua, "1a2b3c");
            canil.distrito = Encriptar.Encrypt(canilF.distrito, "cba321");
            canil.nib = Encriptar.Encrypt(canilF.nib, "b32a1c");
            canil.nome = Encriptar.Encrypt(canilF.nome, "bac321");
            canil.contacto = Encriptar.Encrypt(canilF.contacto, "1c2b3a");
            canil.estado = canilF.estado;

            _context.Entry(canil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CanilExists(id))
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

        // POST: api/Canis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<Canil>> PostCanil(RecieveCanil canilF)
        {
            User user = new User();

            user.email = canilF.email;
            user.password = canilF.password;
            user.tipo = canilF.tipo;
            user.encriptado = 1;

            await _usersController.PostUser(user);

            Canil canil = new Canil();

            canil.email = canilF.email;
            canil.nib = canilF.nib;
            canil.nome = canilF.nome;
            canil.capacidadeOcupada = canilF.capacidadeOcupada;
            canil.capacidadeTotal = canilF.capacidadeTotal;
            canil.distrito = canilF.distrito;
            canil.rua = canilF.rua;
            canil.localidade = canilF.localidade;
            canil.contacto = canilF.contacto;
            canil.estado = canilF.estado;
            canil.encriptado = 1;

            canil.localidade = Encriptar.Encrypt(canil.localidade, "123abc");
            canil.rua = Encriptar.Encrypt(canil.rua, "1a2b3c");
            canil.distrito = Encriptar.Encrypt(canil.distrito, "cba321");
            canil.nib = Encriptar.Encrypt(canil.nib, "b32a1c");
            canil.nome = Encriptar.Encrypt(canil.nome, "bac321");
            canil.contacto = Encriptar.Encrypt(canil.contacto, "1c2b3a");

            _context.Canil.Add(canil);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CanilExists(canil.email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            Horario horario1 = new Horario();
            Horario horario2 = new Horario();
            Horario horario3 = new Horario();
            Horario horario4 = new Horario();
            Horario horario5 = new Horario();
            Horario horario6 = new Horario();
            Horario horario7 = new Horario();

            horario1.dataInicio = DateTime.Parse(canilF.dataInicio1);
            horario1.dataFim = DateTime.Parse(canilF.dataFim1);
            horario1.capacidade = Int32.Parse(canilF.capacidade1);
            horario1.registados = 0;
            horario1.dia = 1;
            horario1.canil_user_email = canilF.email;

            horario2.dataInicio = DateTime.Parse(canilF.dataInicio2);
            horario2.dataFim = DateTime.Parse(canilF.dataFim2);
            horario2.capacidade = Int32.Parse(canilF.capacidade2);
            horario2.registados = 0;
            horario2.dia = 2;
            horario2.canil_user_email = canilF.email;

            horario3.dataInicio = DateTime.Parse(canilF.dataInicio3);
            horario3.dataFim = DateTime.Parse(canilF.dataFim3);
            horario3.capacidade = Int32.Parse(canilF.capacidade3);
            horario3.registados = 0;
            horario3.dia = 3;
            horario3.canil_user_email = canilF.email;

            horario4.dataInicio = DateTime.Parse(canilF.dataInicio4);
            horario4.dataFim = DateTime.Parse(canilF.dataFim4);
            horario4.capacidade = Int32.Parse(canilF.capacidade4);
            horario4.registados = 0;
            horario4.dia = 4;
            horario4.canil_user_email = canilF.email;

            horario5.dataInicio = DateTime.Parse(canilF.dataInicio5);
            horario5.dataFim = DateTime.Parse(canilF.dataFim5);
            horario5.capacidade = Int32.Parse(canilF.capacidade5);
            horario5.registados = 0;
            horario5.dia = 5;
            horario5.canil_user_email = canilF.email;

            horario6.dataInicio = DateTime.Parse(canilF.dataInicio6);
            horario6.dataFim = DateTime.Parse(canilF.dataFim6);
            horario6.capacidade = Int32.Parse(canilF.capacidade6);
            horario6.dia = 6;
            horario6.registados = 0;
            horario6.canil_user_email = canilF.email;

            horario7.dataInicio = DateTime.Parse(canilF.dataInicio7);
            horario7.dataFim = DateTime.Parse(canilF.dataFim7);
            horario7.capacidade = Int32.Parse(canilF.capacidade7);
            horario7.registados = 0;
            horario7.dia = 7;
            horario7.canil_user_email = canilF.email;

            await _horariosController.PostHorario(horario1);
            await _horariosController.PostHorario(horario2);
            await _horariosController.PostHorario(horario3);
            await _horariosController.PostHorario(horario4);
            await _horariosController.PostHorario(horario5);
            await _horariosController.PostHorario(horario6);
            await _horariosController.PostHorario(horario7);

            return CreatedAtAction("GetCanil", new { id = canil.email }, canil);
        }

        //GET: api/Canis/Mail
        [HttpPost("Mail")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> SendMail(RecieveMail info)
        {

            var aux = "/Users/carolina/Downloads/" + info.nome;


            MailMessage message = new MailMessage(
                 "caogest@outlook.com",
                 info.mail,
                 "Emissão Recibo Eletrónico - Donativo Monetário",
                 "");
            Attachment data = new Attachment(aux, MediaTypeNames.Application.Octet);

            message.Attachments.Add(data);

            var client = new System.Net.Mail.SmtpClient("SMTP.office365.com");
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("caogest@outlook.com", "LaboratoriosI4");
            client.Credentials = basicAuthenticationInfo;
            await client.SendMailAsync(message);
            client.Dispose();
            message.Dispose();



            System.IO.File.Delete(aux);
            return "Worked";
        }

        //POST: api/Canis/String
        [HttpPost("String")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> FormatString(Canil address)
        {
            string res = address.rua.Replace(' ', '+');
            return res;
        }

        // DELETE: api/Canis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Canil>> DeleteCanil(string id)
        {
            var canil = await _context.Canil.FindAsync(id);
            if (canil == null)
            {
                return NotFound();
            }

            _context.Canil.Remove(canil);
            await _context.SaveChangesAsync();

            return canil;
        }

        private bool CanilExists(string id)
        {
            return _context.Canil.Any(e => e.email == id);
        }
    }
}
