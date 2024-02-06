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
    [Route("v1/comprador")]
    public class CompradorController : Controller
    {
        private IConfiguration _config;
        public CompradorController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("cadastro")]
        public IActionResult CadastroComprador(
            [FromBody] CompradorCadastroRepostory compradorForm,
            [FromServices] CompradorRepository compradorRepository,
            [FromServices] EnderecoRepository enderecoRepository
            )
        {
            Endereco enderecoObj = compradorForm.EnderecoCadastro();
            enderecoRepository.Save(enderecoObj);
            Comprador comprador = compradorForm.CompradorCadastro(enderecoObj);
            compradorRepository.Save(comprador);
            return Ok(comprador);
        }

        [HttpPost("login")]
        public IActionResult Post(
            [FromBody] CompradorLoginRepostory loginRequest,
            [FromServices] CompradorRepository compradorRepository
            )
        {
            string Username = loginRequest.Username;
            string senha = loginRequest.Senha;
            var user = compradorRepository.Login(Username, senha);
            if(user == null){
                return NotFound("Usuário e/ou senha incorreto!");
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, user.Username),
                new Claim(JwtRegisteredClaimNames.NameId, user.CompradorId.ToString()),
            };
            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddDays(30),
              signingCredentials: credentials);

            var token =  new JwtSecurityTokenHandler().WriteToken(Sectoken);
            HttpContext.Session.SetInt32("_compradorId", user.CompradorId);
            HttpContext.Session.SetString("_compradorUsername", user.Username);
            return Ok(token);
        }
    }
}