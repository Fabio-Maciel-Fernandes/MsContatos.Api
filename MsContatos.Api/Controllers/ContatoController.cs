using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MsContatos.Core.Models;
using MsContatos.Infra.Services.Interfaces;
using System.Net;

namespace MsContatos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoServices _contatoService;

        public ContatoController(IContatoServices contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpGet("GetAllAsync")]
        [ProducesResponseType(typeof(IEnumerable<Contato>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllAsync(int? ddd, CancellationToken cancellationToken)
        {
            IEnumerable<Contato> contatos;

            if (ddd is not null)
            {
                contatos = await _contatoService.GetAllAsync(ddd, cancellationToken);
            }
            else
            {
                contatos = await _contatoService.GetAllAsync(cancellationToken);
            }           

            if (contatos.Any())
            {
                return Ok(contatos);
            }
            else
            {
                return NoContent();
            }
        }

        // GET: api/contato/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Contato), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetContato(int id, CancellationToken cancellationToken)
        {
            var contato = await _contatoService.GetByIdAsync(id, cancellationToken);

            if (contato == null)
            {
                return NoContent();
            }

            return Ok(contato);
        }
    }
}
