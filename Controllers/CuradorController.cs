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
            try{
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
            }catch(Exception e){    
                return BadRequest("Erro ao realizar login.");
            }
        }
        
        [Authorize]
        [HttpGet("pendentes/avaliador")]
        public IActionResult GetCadastrosPendentesAvaliador(
            [FromServices] AvaliadorRepository avaliadorRepository
            )
        {
            try{
                List<Avaliador>? listaAvaliadoresPendentes = avaliadorRepository.GetCadastrosPendentes();
                if (listaAvaliadoresPendentes == null){
                    NotFound("Não foram encontrados cadastros pendentes");
                }
                return Ok(listaAvaliadoresPendentes);
            }catch(Exception e){
                return BadRequest("Erro ao trazer cadastros pendentes de avaliadores");
            }
        }

        [Authorize]
        [HttpGet("pendentes/avaliador/{avaliadorId}")]
        public IActionResult GetCadastroAvaliador(
            int avaliadorId,
            [FromServices] AvaliadorRepository avaliadorRepository
            )
        {
            try{
                Avaliador? avaliador = avaliadorRepository.GetAvaliador(avaliadorId);
                if (avaliador == null){
                    NotFound("Não foi possível encontrar o avaliador desejado");
                }
                return Ok(avaliador);
            }catch(Exception e){
                return BadRequest("Erro ao trazer avaliador");
            }
        }
        
        [Authorize]
        [HttpPatch("pendentes/avaliador/{avaliadorId}/{status}")]
        public IActionResult UpdateStatusAvaliador(
            int avaliadorId,
            string status,
            [FromServices] AvaliadorRepository avaliadorRepository
            )
        {
            try{
                Avaliador? avaliador = avaliadorRepository.UpdateStatusAvaliador(avaliadorId, status);
                if (avaliador == null){
                    NotFound("Não foi possível encontrar o avaliador desejado");
                }
                return Ok(avaliador);
            }catch(Exception e){
                return BadRequest("Erro ao cadastrar status avaliador");
            }
        }
        [Authorize]
        [HttpGet("pendentes/proprietarios")]
        public IActionResult GetCadastrosPendentesProprietarios(
            [FromServices] ProprietarioRepository proprietarioRepository
            )
        {
            try{
                List<Proprietario>? listaProprietarioPendentes = proprietarioRepository.GetCadastrosPendentes();
                if (listaProprietarioPendentes == null){
                    NotFound("Não foram encontrados cadastros pendentes");
                }
                return Ok(listaProprietarioPendentes);
            }catch(Exception e){
                return BadRequest("Erro ao cadastrar status proprietários");
            }
        }

        [Authorize]
        [HttpGet("pendentes/proprietario/{proprietarioId}")]
        public IActionResult GetCadastroProprietario(
            int proprietarioId,
            [FromServices] ProprietarioRepository proprietarioRepository
            )
        {
            try{
                Proprietario? proprietario = proprietarioRepository.GetProprietario(proprietarioId);
                if (proprietario == null){
                    NotFound("Não foi possível encontrar o proprietário desejado");
                }
                return Ok(proprietario);
            }catch(Exception e){
                return BadRequest("Erro ao trazer proprietário.");
            }
        }
        [Authorize]
        [HttpPatch("pendentes/proprietario/{proprietarioId}/{status}")]
        public IActionResult UpdateStatusAvaliador(
            int proprietarioId,
            string status,
            [FromServices] ProprietarioRepository proprietarioRepository
            )
        {
            try{
                Proprietario? proprietario = proprietarioRepository.UpdateStatusProprietario(proprietarioId, status);
                if (proprietario == null){
                    NotFound("Não foi possível encontrar o proprietario desejado");
                }
                return Ok(proprietario);
            }catch(Exception e){
                return BadRequest("Erro ao trazer proprietario.");
            }
        }

        [Authorize]
        [HttpGet("lista/obras")]
        public IActionResult GetObras(
            [FromQuery] ObrasArteFiltrosRepository filtros,
            [FromServices] ObrasArteRepository obrasArteRepository
            )
        {
            try{
                List<ObraArte> listaObras = obrasArteRepository.GetObras(filtros);
                if (listaObras == null){
                    return NotFound("Não foram encontradas obras disponíveis");
                }
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
            }catch{
                return BadRequest("Erro ao trazer obra");
            }
        }
        [Authorize]
        [HttpGet("lista/laudo")]
        public IActionResult GetLaudosDisponiveis(
            [FromQuery] LaudosFiltroRepository filtros,
            [FromServices] LaudoRepository laudoRepository
            )
        {
            try{
                List<Laudo> listaLaudos = laudoRepository.GetLaudos(filtros);
                if (listaLaudos == null){
                    return NotFound("Não foram encontrados laudos disponíveis");
                }
                return Ok(listaLaudos);
            }catch(Exception e){
                return BadRequest("Erro ao trazer laudos disponíveis");
            }
        }

        [Authorize]
        [HttpGet("laudo/{laudoId}")]
        public IActionResult GetLaudo(
            int laudoId,
            [FromServices] LaudoRepository laudoRepository
            )
        {
            try{
                Laudo laudo = laudoRepository.GetLaudo(laudoId);
                if (laudo == null){
                    return NotFound("Não foi possível encontrar o laudo desejado.");
                }
                return Ok(laudo);
            }catch{
                return BadRequest("Erro ao trazer laudo");
            }
        }        

        [HttpPost("cadastro/leilao")]
        public IActionResult CadastroLeilao(
            [FromBody] LeilaoCadastroRepository leilaoForm,
            [FromServices] LeilaoRepository leilaoRepository
            )
        {
            try{
                Leilao leilao = leilaoForm.Cadastro();
                leilaoRepository.Save(leilao);
                return Ok(leilao);
            }catch{
                return BadRequest("Erro ao cadastrar leilão");
            }

        }
        [Authorize]
        [HttpGet("lista/leilao")]
        public IActionResult GetLeiloesDisponiveis(
            [FromServices] LeilaoRepository leilaoRepository
            )
        {
            try{
                List<Leilao>? listaLeiloes = leilaoRepository.GetLeiloes();
                if (listaLeiloes == null){
                    return NotFound("Não foram encontrados leiloes disponíveis");
                }
                return Ok(listaLeiloes);
            }catch{
                return BadRequest("Erro ao trazer leilões");
            }
        }

        [HttpPost("cadastro/lote")]
        public IActionResult CadastroLote(
            [FromBody] LoteCadastroRepostory loteForm,
            [FromServices] LoteRepository loteRepository
            )
        {
            try{
                Lote lote = loteForm.Cadastro();
                loteRepository.Save(lote);
                return Ok(lote);
            }catch{
                return BadRequest("Erro ao cadastrar Lote");
            }
        }

        [HttpPost("cadastro/lote/obra")]
        public IActionResult CadastroLoteObra(
            [FromBody] LoteObraCadastroRepostory loteForm,
            [FromServices] ObrasArteRepository obraRepository
            )
        {
            try{
                ObraArte obra = obraRepository.UpdateLoteObra(loteForm.ObraId, loteForm.LoteId);
                return Ok(obra);
            }catch{
                return BadRequest("Erro ao cadastrar obra em lote");
            }
        }

        [Authorize]
        [HttpGet("maiorlance/{loteId}")]
        public IActionResult GetMaiorLance(
            int loteId,
            [FromServices] LanceRepository lanceRepository
            )
        {
            try{
                Lance? ultimoLance = lanceRepository.GetUltimoLance(loteId);
                if (ultimoLance == null){
                    return NotFound("Não foram encontrados lances para este lote.");
                }
                return Ok(ultimoLance);
            }
            catch{
                return BadRequest("Erro ao trazer lance do lote");
            }
        }
        [Authorize]
        [HttpGet("lista/entregas")]
        public IActionResult GetEntregas(
            [FromServices] EntregaRepository entregaRepository
            )
        {
            try{
                List<Entrega>? listaEntregas = entregaRepository.GetTodasEntregas();
                if (listaEntregas == null){
                    return NotFound("Não foram encontrados entregas");
                }
                return Ok(listaEntregas);
            }catch{
                return BadRequest("Erro ao trazer entregas");
            }

        }

        [Authorize]
        [HttpPatch("edicao/obra")]
        public IActionResult PatchObras(
            [FromBody] ObrasArtePatchRepository obraArtePatch,
            [FromServices] ObrasArteRepository obrasArteRepository
            )
        {
            try{
                ObraArte obra = obrasArteRepository.EditObra(obraArtePatch);
                return Ok(obra);
            }catch{
                return BadRequest("Erro ao editar dados da obra");
            }

        }
        [Authorize]
        [HttpPatch("delete/obra/{obraId}")]
        public IActionResult DeleteObra(
            int obraId,
            [FromServices] ObrasArteRepository obrasArteRepository
            )
        {
            try{
                ObraArte obra = obrasArteRepository.DeleteObra(obraId);
                return Ok();
            }catch(Exception e){
                return BadRequest("Erro ao deletar obra");
            }

        }
    }
}