using MsContatos.Core.Models;
using MsContatos.Infra.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MsContatos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CompilacaoController : ControllerBase
    {
        private readonly IServices<Compilacao> _compilacaoService;

        public CompilacaoController(IServices<Compilacao> compilacaoService)
        {
            _compilacaoService = compilacaoService;
        }

        [HttpGet("GetAllAsync")]
        [ProducesResponseType(typeof(IEnumerable<Compilacao>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var resultado = await _compilacaoService.GetAllAsync(cancellationToken);

            if (resultado.Any())
            {
                return Ok(resultado);
            }
            else
            {
                return NoContent();
            }
        }

        // GET: api/compilacao/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Compilacao), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCompilacao(int id, CancellationToken cancellationToken)
        {
            var compilacao = await _compilacaoService.GetByIdAsync(id, cancellationToken);

            if (compilacao == null)
            {
                return NoContent();
            }

            return Ok(compilacao);
        }

        // POST: api/compilacao
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Post(Compilacao compilacao, CancellationToken cancellationToken)
        {
            _compilacaoService.CreateAsync(compilacao);
            return Ok();
        }

        // PUT: api/compilacao/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Compilacao), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, Compilacao compilacao, CancellationToken cancellationToken)
        {
            if (!await _compilacaoService.ExistAsync(id, cancellationToken))
            {
                return NotFound();
            }

            compilacao.id = id;
            _compilacaoService.UpdateAsync(compilacao);

            return NoContent();
        }

        // DELETE: api/compilacao/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Compilacao), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {

            if (!await _compilacaoService.ExistAsync(id, cancellationToken))
            {
                return NotFound();
            }

            _compilacaoService.DeleteAsync(id);

            return NoContent();
        }       
    }
}
