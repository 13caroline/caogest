using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trial2.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using trial2.Results;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace trial2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly trial2Context _context;

        public LoginController(trial2Context context)
        {
            _context = context;
        }

        // POST: api/Login
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ReturnLogin>> LoginUser(User user)
        {
            var check = await (from u in _context.User
                               where u.email == user.email
                               select u).FirstOrDefaultAsync();

            if (check != null)
            {
                var temp = Encriptar.Decrypt(check.password, "abc123");
                if (temp != user.password)
                {
                    return NotFound();
                }
                else
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.email)
                    };
                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("damfdertyuiopsaz"));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var JWToken = new JwtSecurityToken(
                        issuer: "https://localhost:44321",
                        audience: "https://localhost:44321",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds);
                    var token = new JwtSecurityTokenHandler().WriteToken(JWToken);

                    var randomNumber = new byte[32];
                    using (var rng = RandomNumberGenerator.Create())
                    {
                        rng.GetBytes(randomNumber);
                        var reToken = Convert.ToBase64String(randomNumber);
                    }

                    ReturnLogin res = new ReturnLogin();
                    var nome = "Admin";
                    if (check.tipo == 1)
                    {
                        nome = await (from u in _context.Utilizador
                                      where u.email == check.email
                                      select u.nome).FirstOrDefaultAsync();
                    }
                    else if (check.tipo == 2)
                    {
                        nome = await (from u in _context.Canil
                                      where u.email == check.email
                                      select u.nome).FirstOrDefaultAsync();
                    }
                    res.nome = nome;
                    res.tipo = check.tipo;
                    res.token = token;

                    await HttpContext.SignInAsync(principal);
                    return res;
                }
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<string> Logout()
        {
            await HttpContext.SignOutAsync();
            return "Logout";
        }
    }
}
