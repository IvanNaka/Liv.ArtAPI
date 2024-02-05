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
    [Route("v1/avaliador")]
    public class AvaliadorController : Controller
    {
        private IConfiguration _config;
        public AvaliadorController(IConfiguration config) 
        {
            _config = config;
        }

        [HttpPost("cadastro")]
        public IActionResult CadastroAvaliador(
            [FromBody] AvaliadorCadastroRepostory avaliadorForm,
            [FromServices] AvaliadorRepository avaliadorRepository
            )
        {
            Avaliador avaliador = avaliadorForm.AvaliadorCadastro();
            avaliadorRepository.Save(avaliador);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Post(
            [FromBody] AvaliadorLoginRepostory loginRequest,
            [FromServices] AvaliadorRepository avaliadorRepository
            )
        {
            string Username = loginRequest.Username;
            string senha = loginRequest.Senha;
            var user = avaliadorRepository.Login(Username, senha);
            if(user == null){
                return NotFound("Usuário e/ou senha incorreto!");
            }
            if(user.StatusId == "pendente_avaliador"){
                return BadRequest("Usuário aguardando confirmação da Curadoria");
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, user.Username),
                new Claim(JwtRegisteredClaimNames.NameId, user.AvaliadorId.ToString()),
            };
            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddDays(30),
              signingCredentials: credentials);

            var token =  new JwtSecurityTokenHandler().WriteToken(Sectoken);
            HttpContext.Session.SetInt32("_avaliadorId", user.AvaliadorId);
            HttpContext.Session.SetString("_avaliadorUsername", user.Username);
            return Ok(token);
        }

        [Authorize]
        [HttpPost("teste_autorizacao")]
        public IActionResult Teste(
            [FromBody] AvaliadorLoginRepostory avaliadorLogin,
            [FromServices] AvaliadorRepository avaliadorRepository
            )
        {
            //var stream = _config["Jwt:Key"];  
            //var handler = new JwtSecurityTokenHandler();
            //var jwtSecurityToken = handler.ReadJwtToken(token);
            string Username = avaliadorLogin.Username;
            string senha = avaliadorLogin.Senha;
            var user = avaliadorRepository.Login(Username, senha);
            return Ok(user);
        }

        [Authorize]
        [HttpGet("obras")]
        public IActionResult GetObrasAvaliador(
            [FromBody] AvaliadorLoginRepostory avaliadorLogin,
            [FromServices] AvaliadorRepository avaliadorRepository
            )
        {
            string? sessionId = HttpContext.Session.GetString("_avaliadorId");
            string Username = avaliadorLogin.Username;
            string senha = avaliadorLogin.Senha;
            var user = avaliadorRepository.Login(Username, senha);
            return Ok(user);
        }
    }
}