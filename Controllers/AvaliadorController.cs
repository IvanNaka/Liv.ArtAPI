using LivArt;
using Microsoft.AspNetCore.Mvc;

namespace LivArt.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AvaliadorController : Controller
    {
        [HttpPost]
        public IActionResult CadastroAvaliador(
            [FromBody] AvaliadorCadastroRepostory avaliadorForm,
            [FromServices] AvaliadorRepository avaliadorRepository
            )
        {
            Avaliador avaliador = avaliadorForm.AvaliadorCadastro();
            avaliadorRepository.Save(avaliador);
            return Ok();
        }

    }
}