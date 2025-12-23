using AutoMapper;
using EShop.Application.Common;
using EShop.Application.Dtos;
using EShop.Application.Interfaces.Repositories;
using EShop.Domain.Entities;
using MediatR;

namespace EShop.Application.Features.Persona.Commands
{
    public class RegistrarPersonaHandler : IRequestHandler<RegistrarPersonaCommand, Result<ResponseModelDto>>
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;

        public RegistrarPersonaHandler(IPersonaRepository personaRepository, IMapper mapper)
        {
            _personaRepository = personaRepository;
            _mapper = mapper;
        }
        public async Task<Result<ResponseModelDto>> Handle(RegistrarPersonaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var personaEntity = _mapper.Map<PersonaEntity>(request.RegistrarPersonaDto);
                var result = await _personaRepository.RegistrarAsync(personaEntity);
                if (result)
                    return Result<ResponseModelDto>.Success(new ResponseModelDto(personaEntity.IdPersona));
                return Result<ResponseModelDto>.Failure(new ResponseModelDto("No fue posible realizar el registro de la persona."));
            }
            catch (Exception e)
            {
                return Result<ResponseModelDto>.InternalError(new ResponseModelDto(e.Message));
            }
        }
    }
}
