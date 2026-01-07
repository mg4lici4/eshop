using EShop.Application.Common;
using EShop.Application.Dtos;
using EShop.Application.Dtos.Usuario;
using MediatR;

namespace EShop.Application.Features.Usuario.Commands
{
    public class SegundoFaActivarCommand : IRequest<Result<ResponseModelDto>>
    {
        public ActivarSegundoFaDto ActivarSegundoFaDto { get; set; } = default!;
    }
}
