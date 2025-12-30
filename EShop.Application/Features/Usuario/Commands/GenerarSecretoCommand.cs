using EShop.Application.Common;
using EShop.Application.Dtos;
using EShop.Application.Dtos.Usuario;
using MediatR;

namespace EShop.Application.Features.Usuario.Commands
{
    public class GenerarSecretoCommand : IRequest<Result<ResponseModelDto>>
    {
        public required GenerarSecretoDto GenerarSecretoDto { get; set; } = default!;
    }
}
