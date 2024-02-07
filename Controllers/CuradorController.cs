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
    [Route("v1/curador")]
    public class CuradorController : Controller
    {
        private IConfiguration _config;
        public CuradorController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Post(
            [FromBody] AvaliadorLoginRepostory loginRequest,
            [FromServices] CuradorRepository curadorRepository
            )
        {
            string Username = loginRequest.Username;
            string senha = loginRequest.Senha;
            var user = curadorRepository.Login(Username, senha);
            if(user == null){
                return NotFound("Usuário e/ou senha incorreto!");
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, user.Username),
                new Claim(JwtRegisteredClaimNames.NameId, user.CuradorId.ToString()),
            };
            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddDays(30),
              signingCredentials: credentials);

            var token =  new JwtSecurityTokenHandler().WriteToken(Sectoken);
            HttpContext.Session.SetInt32("_curadorId", user.CuradorId);
            HttpContext.Session.SetString("_curadorUsername", user.Username);
            return Ok(token);
        }
        
        [Authorize]
        [HttpGet("pendentes/avaliador")]
        public IActionResult GetCadastrosPendetesAvaliador(
            [FromServices] AvaliadorRepository avaliadorRepository
            )
        {
            List<Avaliador>? listaAvaliadoresPendentes = avaliadorRepository.GetCadastrosPendentes();
            if (listaAvaliadoresPendentes == null){
                NotFound("Não foram encontrados cadastros pendentes");
            }
            return Ok(listaAvaliadoresPendentes);
        }

        [Authorize]
        [HttpGet("pendentes/avaliador/{avaliadorId}")]
        public IActionResult GetCadastroAvaliador(
            int avaliadorId,
            [FromServices] AvaliadorRepository avaliadorRepository
            )
        {
            Avaliador? avaliador = avaliadorRepository.GetAvaliador(avaliadorId);
            if (avaliador == null){
                NotFound("Não foi possível encontrar o avaliador desejado");
            }
            return Ok(avaliador);
        }
        
        [Authorize]
        [HttpPatch("pendentes/avaliador/{avaliadorId}/{status}")]
        public IActionResult UpdateStatusAvaliador(
            int avaliadorId,
            string status,
            [FromServices] AvaliadorRepository avaliadorRepository
            )
        {
            Avaliador? avaliador = avaliadorRepository.UpdateStatusAvaliador(avaliadorId, status);
            if (avaliador == null){
                NotFound("Não foi possível encontrar o avaliador desejado");
            }
            return Ok(avaliador);
        }
        [Authorize]
        [HttpGet("pendentes/proprietarios")]
        public IActionResult GetCadastrosPendentesProprietarios(
            [FromServices] ProprietarioRepository proprietarioRepository
            )
        {
            List<Proprietario>? listaProprietarioPendentes = proprietarioRepository.GetCadastrosPendentes();
            if (listaProprietarioPendentes == null){
                NotFound("Não foram encontrados cadastros pendentes");
            }
            return Ok(listaProprietarioPendentes);
        }

        [Authorize]
        [HttpGet("pendentes/proprietario/{proprietarioId}")]
        public IActionResult GetCadastroProprietario(
            int proprietarioId,
            [FromServices] ProprietarioRepository proprietarioRepository
            )
        {
            Proprietario? proprietario = proprietarioRepository.GetProprietario(proprietarioId);
            if (proprietario == null){
                NotFound("Não foi possível encontrar o proprietário desejado");
            }
            return Ok(proprietario);
        }
        [Authorize]
        [HttpPatch("pendentes/avaliador/{proprietarioId}/{status}")]
        public IActionResult UpdateStatusAvaliador(
            int proprietarioId,
            string status,
            [FromServices] ProprietarioRepository proprietarioRepository
            )
        {
            Proprietario? proprietario = proprietarioRepository.UpdateStatusProprietario(proprietarioId, status);
            if (proprietario == null){
                NotFound("Não foi possível encontrar o proprietario desejado");
            }
            return Ok(proprietario);
        }
    }
}