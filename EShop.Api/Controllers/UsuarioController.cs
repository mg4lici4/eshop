using EShop.Application.Dtos.Usuario;
using EShop.Application.Features.Usuario.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Api.Controllers
{
    [ApiController]
    [Route("api/v1/eshop/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "Registrar Usuario")]
        public async Task<IActionResult> Registrar(RegistrarUsuarioDto registrarUsuarioDto)
        {
            var command = new RegistrarUsuarioCommand() { RegistrarUsuarioDto = registrarUsuarioDto };
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
                return Ok(result.Value);

            return StatusCode(result.StatusCode, result.Value);
        }

        [HttpPost("activar", Name = "Activar")]
        public async Task<IActionResult> Activar(ActivarUsuarioDto activarUsuarioDto)
        {
            var command = new ActivarUsuarioCommand() { ActivarUsuarioDto = activarUsuarioDto };
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
                return Ok(result.Value);

            return StatusCode(result.StatusCode, result.Value);
        }
    }
}
