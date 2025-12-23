using EShop.Application.Common;
using EShop.Application.Dtos;
using EShop.Application.Dtos.Persona;
using MediatR;

namespace EShop.Application.Features.Persona.Commands
{
    public class RegistrarPersonaCommand : IRequest<Result<ResponseModelDto>>
    {
        public required RegistrarPersonaDto RegistrarPersonaDto { get; set; }
    }
}
