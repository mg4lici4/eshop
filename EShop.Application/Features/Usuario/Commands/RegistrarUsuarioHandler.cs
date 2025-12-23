using AutoMapper;
using EShop.Application.Common;
using EShop.Application.Dtos;
using EShop.Application.Interfaces;
using EShop.Application.Interfaces.Repositories;
using EShop.Application.Interfaces.Security;
using EShop.Domain.Entities;
using EShop.Domain.Interfaces;
using MediatR;

namespace EShop.Application.Features.Usuario.Commands
{
    public class RegistrarUsuarioHandler : IRequestHandler<RegistrarUsuarioCommand, Result<ResponseModelDto>>
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IOrigenRepository _origenRepository;
        private readonly IPasswordHasherSecurity _passwordHasherSecurity;
        private readonly IEventProducer _eventProducer;
        private readonly IMapper _mapper;
        public RegistrarUsuarioHandler(IPersonaRepository personaRepository, IUsuarioRepository usuarioRepository, IOrigenRepository origenRepository, IPasswordHasherSecurity passwordHasherSecurity, 
            IEventProducer eventProducer, IMapper mapper)
        {
            _personaRepository = personaRepository;
            _usuarioRepository = usuarioRepository;
            _origenRepository = origenRepository;
            _passwordHasherSecurity = passwordHasherSecurity;
            _eventProducer = eventProducer;
            _mapper = mapper;
        }
        public async Task<Result<ResponseModelDto>> Handle(RegistrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var personaEntity = await _personaRepository.BuscarPorIdPersonaAsync(request.RegistrarUsuarioDto.IdPersona);
                if (personaEntity is null) 
                    return Result<ResponseModelDto>.Failure(new ResponseModelDto("No se encontro información con los datos proporcionados."));

                var origenEntity = await _origenRepository.BuscarPorClaveAsync(request.RegistrarUsuarioDto.Aplicativo);
                if (origenEntity is null)
                    return Result<ResponseModelDto>.Failure(new ResponseModelDto("No se encontro información con los datos proporcionados."));

                var usuarioPrevio = await _usuarioRepository.BuscarPorIdPersonaAsync(request.RegistrarUsuarioDto.IdPersona);
                if (usuarioPrevio is not null)
                    return Result<ResponseModelDto>.Failure(new ResponseModelDto("No fue posible realizar el registro del usuario, realizar recuperación de claves."));

                var usuarioEntity = _mapper.Map<UsuarioEntity>(request.RegistrarUsuarioDto);
                usuarioEntity.Nombre = personaEntity.Correo;
                usuarioEntity.IdOrigen = origenEntity.IdOrigen;
                usuarioEntity.Activo = 0;
                usuarioEntity.Bloqueo = 0;
                usuarioEntity.Contrasenia = _passwordHasherSecurity.Generar(request.RegistrarUsuarioDto.Contrasenia);

                var result = await _usuarioRepository.RegistrarAsync(usuarioEntity);
                if (result)
                {
                    //var userEvent = new UsuarioCreadoEvent
                    //{
                    //    IdUsuario = usuarioEntity.IdUsuario,
                    //    Nombre = personaEntity.Nombre,
                    //    FechaCreacion = DateTime.UtcNow
                    //};

                    //await _eventProducer.ProduceAsync("usuarios-topic", userEvent);
                    return Result<ResponseModelDto>.Success(new ResponseModelDto(usuarioEntity.IdUsuario));                 

                }

                return Result<ResponseModelDto>.Failure(new ResponseModelDto("No fue posible realizar el registro del usuario."));
            }
            catch (Exception e)
            {
                return Result<ResponseModelDto>.InternalError(new ResponseModelDto(e.Message));
            }
        }
    }
}
