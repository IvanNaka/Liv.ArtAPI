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

        [Authorize]
        [HttpGet("lista/obras")]
        public IActionResult GetObrasAvaliador(
            [FromQuery] ObrasArteFiltrosRepository filtros,
            [FromServices] ObrasArteRepository obrasArteRepository
            )
        {
            List<ObraArte> listaObras = obrasArteRepository.GetObras(filtros);
            if (listaObras == null){
                return NotFound("Não foram encontradas obras disponíveis");
            }
            return Ok(listaObras);
        }

        [Authorize]
        [HttpGet("obra/{obraId}")]
        public IActionResult GetObra(
            int obraId,
            [FromServices] ObrasArteRepository obrasArteRepository
            )
        {
            ObraArte obra = obrasArteRepository.GetObrasId(obraId);
            if (obra == null){
                return NotFound("Não foi possível encontrar a obra desejada.");
            }
            return Ok(obra);
        }
        [Authorize]
        [HttpGet("lista/laudo")]
        public IActionResult GetLaudosDisponiveis(
            [FromQuery] LaudosFiltroRepository filtros,
            [FromServices] LaudoRepository laudoRepository
            )
        {
            List<Laudo> listaLaudos = laudoRepository.GetLaudos(filtros);
            if (listaLaudos == null){
                return NotFound("Não foram encontrados laudos disponíveis");
            }
            return Ok(listaLaudos);
        }

        [Authorize]
        [HttpGet("laudo/{laudoId}")]
        public IActionResult GetLaudo(
            int laudoId,
            [FromServices] LaudoRepository laudoRepository
            )
        {
            Laudo laudo = laudoRepository.GetLaudo(laudoId);
            if (laudo == null){
                return NotFound("Não foi possível encontrar o laudo desejado.");
            }
            return Ok(laudo);
        }        

        [HttpPost("cadastro/leilao")]
        public IActionResult CadastroLeilao(
            [FromBody] LeilaoCadastroRepository leilaoForm,
            [FromServices] LeilaoRepository leilaoRepository
            )
        {
            Leilao leilao = leilaoForm.Cadastro();
            leilaoRepository.Save(leilao);
            return Ok(leilao);
        }
        [Authorize]
        [HttpGet("lista/leilao")]
        public IActionResult GetLeiloesDisponiveis(
            [FromServices] LeilaoRepository leilaoRepository
            )
        {
            List<Leilao>? listaLeiloes = leilaoRepository.GetLeiloes();
            if (listaLeiloes == null){
                return NotFound("Não foram encontrados leiloes disponíveis");
            }
            return Ok(listaLeiloes);
        }

        [HttpPost("cadastro/lote")]
        public IActionResult CadastroLote(
            [FromBody] LoteCadastroRepostory loteForm,
            [FromServices] LoteRepository loteRepository
            )
        {
            Lote lote = loteForm.Cadastro();
            loteRepository.Save(lote);
            return Ok(lote);
        }

        [HttpPost("cadastro/lote/obra")]
        public IActionResult CadastroLoteObra(
            [FromBody] LoteObraCadastroRepostory loteForm,
            [FromServices] ObrasArteRepository obraRepository
            )
        {
            ObraArte obra = obraRepository.UpdateLoteObra(loteForm.ObraId, loteForm.LoteId);
            return Ok(obra);
        }

        [Authorize]
        [HttpGet("maiorlance/{loteId}")]
        public IActionResult GetMaiorLance(
            int loteId,
            [FromServices] LanceRepository lanceRepository
            )
        {
            Lance? ultimoLance = lanceRepository.GetUltimoLance(loteId);
            if (ultimoLance == null){
                return NotFound("Não foram encontrados lances para este lote.");
            }
            return Ok(ultimoLance);
        }
        [Authorize]
        [HttpGet("lista/entregas")]
        public IActionResult GetEntregas(
            [FromServices] EntregaRepository entregaRepository
            )
        {
        List<Entrega>? listaEntregas = entregaRepository.GetTodasEntregas();
        if (listaEntregas == null){
            return NotFound("Não foram encontrados entregas");
        }
        return Ok(listaEntregas);
        }

        [Authorize]
        [HttpPatch("edicao/obra")]
        public IActionResult PatchObras(
            [FromBody] ObrasArtePatchRepository obraArtePatch,
            [FromServices] ObrasArteRepository obrasArteRepository
            )
        {
            ObraArte obra = obrasArteRepository.EditObra(obraArtePatch);
            return Ok(obra);
        }
        [Authorize]
        [HttpPatch("delete/obra/{obraId}")]
        public IActionResult DeleteObra(
            int obraId,
            [FromServices] ObrasArteRepository obrasArteRepository
            )
        {
            ObraArte obra = obrasArteRepository.DeleteObra(obraId);
            return Ok();
        }
    }
}