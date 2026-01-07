using EShop.Application.Dtos.Login;
using EShop.Application.Features.Login.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Api.Controllers
{
    [ApiController]
    [Route("api/v1/eshop/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "Validar credenciales")]
        public async Task<IActionResult> ValidarCredenciales(ValidarCredencialesDto validarCredencialesDto)
        {
            var command = new LoginCredencialesCommand() { LoginCredencialesDto = validarCredencialesDto };
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
                return Ok(result.Value);

            return StatusCode(result.StatusCode, result.Value);
        }
    }
}
