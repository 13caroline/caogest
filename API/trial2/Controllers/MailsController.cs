﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trial2.Models;
using trial2.Results;

namespace trial2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private readonly trial2Context _context;

        public MailsController(trial2Context context)
        {
            _context = context;
        }

        // POST: api/Mails
        [HttpPost]
        public async Task<ActionResult<string>> PostMail(Mail mail)
        {
            MailMessage message = new MailMessage(
                "",
                mail.email,
                mail.assunto,
                mail.texto);

            var client = new System.Net.Mail.SmtpClient("SMTP.office365.com");
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("", "");
            client.Credentials = basicAuthenticationInfo;
            await client.SendMailAsync(message);
            client.Dispose();
            message.Dispose();

           
            return "Worked";
        }
    }
}
