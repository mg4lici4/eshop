using EShop.Application.Common;
using EShop.Application.Dtos;
using MediatR;

namespace EShop.Application.Features.Origen.Queries
{
    public class ObtenerOrigenesQuery : IRequest<Result<ResponseModelDto>>
    {
    }
}
