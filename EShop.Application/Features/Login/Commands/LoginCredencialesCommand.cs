using EShop.Application.Common;
using EShop.Application.Dtos;
using EShop.Application.Dtos.Login;
using MediatR;

namespace EShop.Application.Features.Login.Commands
{
    public class LoginCredencialesCommand : IRequest<Result<ResponseModelDto>>
    {
        public required ValidarCredencialesDto LoginCredencialesDto { get; set; } = default!;
    }
}
