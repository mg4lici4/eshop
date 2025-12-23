using AutoMapper;
using EShop.Application.Common;
using EShop.Application.Dtos;
using EShop.Application.Dtos.Origen;
using EShop.Application.Interfaces.Repositories;
using MediatR;

namespace EShop.Application.Features.Origen.Queries
{
    public class ObtenerOrigenesHandler : IRequestHandler<ObtenerOrigenesQuery, Result<ResponseModelDto>>
    {
        private readonly IOrigenRepository _origenRepository;
        private readonly IMapper _mapper;
        public ObtenerOrigenesHandler(IOrigenRepository origenRepository, IMapper mapper)
        {
            _origenRepository = origenRepository;
            _mapper = mapper;
        }
        public async Task<Result<ResponseModelDto>> Handle(ObtenerOrigenesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var origenesEntities = await _origenRepository.ObtenerRegistrosAsync();
                var origenesDtos = _mapper.Map<List<OrigenDto>>(origenesEntities);
                return Result<ResponseModelDto>.Success(new ResponseModelDto(origenesDtos));
            }
            catch (Exception e)
            {
                return Result<ResponseModelDto>.InternalError(new ResponseModelDto(e.Message));
            }
        }
    }
}
