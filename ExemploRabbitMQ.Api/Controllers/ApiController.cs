using Microsoft.AspNetCore.Mvc;

namespace ExemploRabbitMQ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult ObterRelatorios() =>
            Ok(Data.Relatorio.RelatorioData.Relatorios);

        [HttpPost]
        public IActionResult SolicitarRelatorio([FromBody] string nomeRelatorio)
        {
            var novoRelatorio = new Data.Relatorio.SolicitacaoRelatorio
            {
                Id = Guid.NewGuid(),
                Nome = nomeRelatorio,
                Status = Data.Relatorio.Status.Pendente,
                DataProcessamento = null
            };
            Data.Relatorio.RelatorioData.Relatorios.Add(novoRelatorio);
            return CreatedAtAction(nameof(ObterRelatorios), new { id = novoRelatorio.Id }, novoRelatorio);
        }
    }
}
