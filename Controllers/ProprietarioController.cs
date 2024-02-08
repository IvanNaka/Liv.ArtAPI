using Liv.ArtAPI.Repositories;
using LivArt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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
            try
            {
                Proprietario proprietario = proprietarioForm.ProprietarioCadastro();
                proprietarioRepository.Save(proprietario);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao cadastrar proprietário.");
            }

        }

        [HttpPost("login")]
        public IActionResult Post(
            [FromBody] ProprietarioLoginRepostory loginRequest,
            [FromServices] ProprietarioRepository proprietarioRepository
            )
        {
            try
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
                HttpContext.Session.SetInt32("_proprietarioId", user.ProprietarioId);
                HttpContext.Session.SetString("_proprietarioUsername", user.Username);
                return Ok(token);
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao cadastrar Login.");
            }
        }


        [HttpPost("cadastro/obra")]
        public IActionResult CadastroObraProprietario(
            [FromBody] ProprietarioObraCadastroRepository ObraArteForm,
            [FromServices] ObrasArteRepository ObrasArte)
        {
            try
            {
                ObraArte ObraArte = ObraArteForm.ObraArteCadastro();
                ObrasArte.Save(ObraArte);  // nao entendi a lógica por aqui
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao cadastrar Obra.");
            }
        }

        [Authorize]
        [HttpGet("obras")]
        public IActionResult GetObrasProprietario(
            [FromQuery] ObrasArteFiltrosRepository filtros,
            [FromServices] ObrasArteRepository obrasArteRepository
            )
        {
            try
            {
                int? proprietarioId = HttpContext.Session.GetInt32("_proprietarioId");
                if (proprietarioId == null)
                {
                    return Unauthorized("Acesso negado.");
                }
                List<ObraArte> listaObras = obrasArteRepository.GetObrasProprietario(proprietarioId, filtros);
                return Ok(listaObras);
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao trazer obras");
            }
        }


        [Authorize]
        [HttpGet("obras/laudo/{laudoId}")]
        public IActionResult GetLaudo(
            int laudoId,
            [FromQuery] LaudoRepository filtros,
            [FromServices] LaudoRepository laudoRepository
            )
        {
            try
            {
                Laudo? laudo = laudoRepository.GetLaudo(laudoId);
                if (laudo == null)
                {
                    return NotFound("Não foi possível encontrar o laudo desta obra.");
                }
                return Ok(laudo);
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao trazer laudo da obra.");
            }
        }


        [Authorize]
        [HttpGet("avaliadores")]
        public IActionResult GetAvaliador(
            int avaliadorId,
            [FromServices] AvaliadorRepository avaliadorRepository
        )
        {
            try
            {
                Avaliador avaliador = avaliadorRepository.GetAvaliador(avaliadorId);
                if (avaliador == null)
                {
                    return NotFound("Avaliador não encontrado");
                }
                return Ok(avaliador);
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao trazer avaliador.");
            }

        }

        [Authorize]
        [HttpGet("leilao/lances/{loteId}")]
        public IActionResult GetMaiorLance(
            int loteId,
            [FromServices] LanceRepository lanceRepository
        )
        {
            try
            {
                Lance? ultimoLance = lanceRepository.GetUltimoLance(loteId);
                if (ultimoLance == null)
                {
                    return NotFound("Não foram encontrados lances para este lote.");
                }
                return Ok(ultimoLance);
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao trazer maior lance.");
            }
        }

        [Authorize]
        [HttpGet("leilao/{leilaoId}")]
        public IActionResult FinalizarLeilao(
            int leilaoId,
            [FromServices] LeilaoRepository leilaoRepository
        )
        {
            try
            {
                Leilao? leilao = leilaoRepository.GetLeilaoId(leilaoId);
                if (leilao == null)
                {
                    return NotFound("Leilão não encontrado");
                }
                if (leilao.DataFim <= DateTime.Now)
                {
                    return NotFound("O leilão pesquisado já foi encerrado.");
                }

                return Ok(leilaoId);
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao trazer Informações do Leilão.");
            }
        }

        [Authorize]
        [HttpGet("leilao/entrega")]
        public IActionResult GetEntrega(
        int compradorId,
        [FromServices] EntregaRepository entregaRepository
        )
        {
            try
            {
                var entregas = entregaRepository.GetEntregaComprador(compradorId);
                if (entregas == null || entregas.Count == 0)
                {
                    return NotFound("Não foram encontradas entregas");
                }
                return Ok(entregas);
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao trazer entregas.");
            }
        }

        [HttpPost("entrega/cadastro")]
        public IActionResult CadastroObraProprietario(
        [FromBody] EntregaCadastroRepository EntregaForm,
        [FromServices] EntregaRepository entregaRepository
        )
        {
            try
            {
                Entrega entrega = EntregaForm.Cadastro();
                entregaRepository.Save(entrega);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao cadastrar entrega.");
            }
        }



    }
}