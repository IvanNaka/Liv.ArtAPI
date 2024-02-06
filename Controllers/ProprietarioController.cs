using Liv.ArtAPI.Repositories;
using LivArt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LivArt.Controllers
{

    [ApiController]
    [Route("v1/proprietario")]
    public class ProprietarioController : Controller
    {
        private IConfiguration _config;
        public ProprietarioController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("cadastroproprietario")]
        public IActionResult CadastroProprietario(
            [FromBody] ProprietarioCadastroRepository proprietarioForm,
            [FromServices] ProprietarioRepository proprietarioRepository
            )
        {
            Proprietario proprietario = proprietarioForm.ProprietarioCadastro();
            proprietarioRepository.Save(proprietario);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Post(
            [FromBody] ProprietarioLoginRepostory loginRequest,
            [FromServices] ProprietarioRepository proprietarioRepository
            )
        {
            string Username = loginRequest.Username;
            string senha = loginRequest.Senha;
            var user = proprietarioRepository.Login(Username, senha);
            if (user == null)
            {
                return NotFound("Usuário e/ou senha incorreto!");
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, user.Username),
                new Claim(JwtRegisteredClaimNames.NameId, user.ProprietarioId.ToString()),
            };
            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddDays(30),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return Ok(token);
        }


        [Authorize]
        [HttpGet("obras")]
        public IActionResult GetObrasProprietario(
            [FromQuery] ObrasArteRepository filtros,
            [FromServices] ObrasArteRepository obrasArteRepository
            )
        {
            string Username = proprietarioLogin.Username;
            string senha = proprietarioLogin.Senha;
            var user = proprietarioRepository.Login(Username, senha);
            return Ok(user);
        }
    }
}