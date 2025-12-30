using EShop.Application.Common;
using EShop.Application.Dtos;
using EShop.Application.Dtos.Login;
using MediatR;

namespace EShop.Application.Features.Login.Queries
{
    public class ValidarOtpQuery : IRequest<Result<ResponseModelDto>>
    {
        public ValidarOtpDto ValidarOtpDto { get; set; } = default!;
    }
}
