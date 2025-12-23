using EShop.Application.Common;
using EShop.Application.Dtos;
using EShop.Application.Dtos.Usuario;
using MediatR;

namespace EShop.Application.Features.Usuario.Commands
{
    public class ActivarUsuarioCommand : IRequest<Result<ResponseModelDto>>
    {
        public required ActivarUsuarioDto ActivarUsuarioDto { get; set; }
    }
}
