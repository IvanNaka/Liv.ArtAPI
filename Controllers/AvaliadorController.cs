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
            try{
                Avaliador avaliador = avaliadorForm.AvaliadorCadastro();
                avaliadorRepository.Save(avaliador);
                return Ok(avaliador);
            }catch(Exception e){
                return BadRequest("Erro ao cadastrar avaliador");
            }
        }

        [HttpPost("login")]
        public IActionResult Post(
            [FromBody] AvaliadorLoginRepostory loginRequest,
            [FromServices] AvaliadorRepository avaliadorRepository
            )
        {
            try{
                string Username = loginRequest.Username;
                string senha = loginRequest.Senha;
                var user = avaliadorRepository.Login(Username, senha);
                if(user == null){
                    return NotFound("Usuário e/ou senha incorreto!");
                }
                if(user.StatusId == "pendente_avaliador"){
                    return Unauthorized("Usuário aguardando confirmação da Curadoria");
                }
                if(user.StatusId == "reprovado_avaliador"){
                    return Unauthorized("Usuário reprovado pela Curadoria");
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
            }catch(Exception e){
                return BadRequest("Erro ao realizar login");
            }
            
        }

        [Authorize]
        [HttpGet("lista_obras")]
        public IActionResult GetObrasAvaliador(
            [FromQuery] ObrasArteFiltrosRepository filtros,
            [FromServices] ObrasArteRepository obrasArteRepository
            )
        {
            try{
                int? avaliadorId = HttpContext.Session.GetInt32("_avaliadorId");
                if (avaliadorId == null){
                    return Unauthorized("Acesso negado.");
                }
                List<ObraArte> listaObras = obrasArteRepository.GetObrasAvaliador(avaliadorId, filtros);
                return Ok(listaObras);
            }catch(Exception e){
                return BadRequest("Erro ao trazer obras");
            }
        }

        [Authorize]
        [HttpGet("obra/{obraId}")]
        public IActionResult GetObra(
            int obraId,
            [FromServices] ObrasArteRepository obrasArteRepository
            )
        {
            try{
                ObraArte obra = obrasArteRepository.GetObrasId(obraId);
                if (obra == null){
                    return NotFound("Não foi possível encontrar a obra desejada.");
                }
                return Ok(obra);
            }catch(Exception e){
                return BadRequest("Erro ao trazer obra");
            }
        }

        [HttpPost("cadastro/laudo")]
        public IActionResult CadastroLaudo(
            [FromBody] LaudoCadastroRepostory laudoForm,
            [FromServices] LaudoRepository laudoRepository
            )
        {
            try{
                int? avaliadorId = HttpContext.Session.GetInt32("_avaliadorId");
                if (avaliadorId == null){
                    return Unauthorized("Acesso negado.");
                }
                Laudo laudo = laudoForm.Cadastro(avaliadorId);
                laudoRepository.Save(laudo);
                return Ok(laudo);
            }catch(Exception e){
                return BadRequest("Erro ao cadastrar laudo");
            }
        }
    }
}