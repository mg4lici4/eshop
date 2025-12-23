using EShop.Application.Features.Origen.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Api.Controllers
{
    [ApiController]
    [Route("api/v1/eshop/[controller]")]
    public class OrigenController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrigenController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet(Name = "ConsultarRegistros")]
        public async Task<IActionResult> ConsultarRegistros()
        {
            var query = new ObtenerOrigenesQuery();
            var result = await _mediator.Send(query);

            if (result.IsSuccess)
                return Ok(result.Value);

            return StatusCode(result.StatusCode, result.Value);
        }
    }
}
