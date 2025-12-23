using EShop.Application.Dtos.Persona;
using EShop.Application.Features.Persona.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Api.Controllers
{    
    [ApiController]
    [Route("api/v1/eshop/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PersonaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "Registrar Persona")]
        public async Task<IActionResult> Registrar(RegistrarPersonaDto registrarPersonaDto)
        {
            var command = new RegistrarPersonaCommand() { RegistrarPersonaDto = registrarPersonaDto };
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
                return Ok(result.Value);

            return StatusCode(result.StatusCode, result.Value);
        }
    }
}
