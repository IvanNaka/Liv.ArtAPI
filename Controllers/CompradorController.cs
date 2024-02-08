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
            try{
                Endereco enderecoObj = compradorForm.EnderecoCadastro();
                enderecoRepository.Save(enderecoObj);
                Comprador comprador = compradorForm.CompradorCadastro(enderecoObj);
                compradorRepository.Save(comprador);
                return Ok(comprador);
            }catch(Exception e){
                return BadRequest("Erro ao realizar cadastro");
            }
        }

        [HttpPost("login")]
        public IActionResult Post(
            [FromBody] CompradorLoginRepostory loginRequest,
            [FromServices] CompradorRepository compradorRepository
            )
        {
            try{
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
            }catch(Exception e){
                return BadRequest("Erro ao realizar login");
            }

        }
        [Authorize]
        [HttpGet("lista/obras")]
        public IActionResult GetObras(
            [FromQuery] string? artista, 
            [FromQuery] string? titulo,
            [FromQuery] DateOnly? dataCriacao,
            [FromQuery] string? tecnica,
            [FromQuery] string? proprietario,
            [FromQuery] int? loteId,
            [FromServices] ObrasArteRepository obrasArteRepository
            )
        {
            try{
                ObrasArteFiltrosRepository filtros = new ObrasArteFiltrosRepository();
                filtros.artista = artista;
                filtros.titulo = titulo;
                filtros.dataCriacao = dataCriacao;
                filtros.tecnica = tecnica;
                filtros.proprietario = proprietario;
                filtros.loteId = loteId;
                List<ObraArte>? listaObras = obrasArteRepository.GetObras(filtros);
                if (listaObras == null){
                    return NotFound("Não foram encontradas obras");
                }
                return Ok(listaObras);
            }catch(Exception e){
                return BadRequest("Erro ao trazer obras");
            }
        }
        [Authorize]
        [HttpGet("lista/leiloes")]
        public IActionResult GetLeiloes(
            [FromServices] LeilaoRepository leilaoRepository
            )
        {
            try{
                List<Leilao>? listaLeilao = leilaoRepository.GetLeiloes();
                if (listaLeilao == null){
                    return NotFound("Não foram encontrados leilões disponíveis");
                }
                return Ok(listaLeilao);
            }catch(Exception e){
                return BadRequest("Erro ao trazer leilões disponíveis");
            }

        }
        [Authorize]
        [HttpGet("lista/lote")]
        public IActionResult GetLotes(
            [FromServices] LoteRepository loteRepository
            )
        {
            try{
                List<Lote>? listaLotes = loteRepository.GetLotes();
                if (listaLotes == null){
                    return NotFound("Não foram encontrados lotes disponíveis");
                }
                return Ok(listaLotes);
            }catch(Exception e){
                return BadRequest("Erro ao trazer lotes disponíveis");
            }

        }

        [HttpPost("cadastro/lance")]
        public IActionResult CadastroLance(
            [FromBody] LanceCadastroRepostory lanceForm,
            [FromServices] LanceRepository lanceRepository
            )
        {
            try{
                int? compradorId = HttpContext.Session.GetInt32("_compradorId");
                if (compradorId == null){
                    return Unauthorized("Acesso negado.");
                }
                Lance? ultimoLance = lanceRepository.GetUltimoLance(lanceForm.LoteId);
                if (ultimoLance != null & lanceForm.Valor <= ultimoLance.Valor){
                    return BadRequest("Valor de lance deve ser maior que o lance atual");
                }
                Lance lance = lanceForm.Cadastro(compradorId);
                lanceRepository.Save(lance);
                return Ok(lance);
            }catch(Exception e){
                return BadRequest("Erro ao cadastrar lance");
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
            }catch(Exception e){
                return BadRequest("Erro ao trazer último lance.");
            }
        }
        [HttpPost("cadastro/pagamento")]
        public IActionResult CadastroPagamento(
            [FromBody] PagamentoCadastroRepostory pagamentoForm,
            [FromServices] PagamentoRepository pagamentoRepository,
            [FromServices] CartaoRepository cartaoRepository
            )
        {
            try{
                int? compradorId = HttpContext.Session.GetInt32("_compradorId");
                if (compradorId == null){
                    return Unauthorized("Acesso negado.");
                }
                Cartao cartao = pagamentoForm.CadastroCartao(compradorId);
                cartaoRepository.Save(cartao);
                Pagamento pagamento = pagamentoForm.CadastroPagamento(compradorId, cartao.CartaoId);
                pagamentoRepository.Save(pagamento);
                return Ok(pagamento);
            }catch(Exception e){
                return BadRequest("Erro ao cadastrar pagamento");
            }
        }
        [Authorize]
        [HttpGet("lista/entregas")]
        public IActionResult GetEntregas(
            [FromServices] EntregaRepository entregaRepository
            )
        {
            try{
                int? compradorId = HttpContext.Session.GetInt32("_compradorId");
                if (compradorId == null){
                    return Unauthorized("Acesso negado.");
                }
                List<Entrega>? listaEntregas = entregaRepository.GetEntregaComprador((int)compradorId);
                if (listaEntregas == null){
                    return NotFound("Não foram encontrados entregas");
                }
                return Ok(listaEntregas);
            }catch(Exception e){
                return BadRequest("Erro ao trazer informações das entregas");
            }
        }
    }
}