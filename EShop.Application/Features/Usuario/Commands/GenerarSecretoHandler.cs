using EShop.Application.Common;
using EShop.Application.Dtos;
using EShop.Application.Interfaces.Repositories;
using EShop.Domain.Entities;
using MediatR;
using OtpNet;
using System.Web;

namespace EShop.Application.Features.Usuario.Commands
{
    public class GenerarSecretoHandler : IRequestHandler<GenerarSecretoCommand, Result<ResponseModelDto>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISegundoFARepository _segundoFARepository;

        public GenerarSecretoHandler(IUsuarioRepository usuarioRepository, ISegundoFARepository segundoFARepository)
        {
            _usuarioRepository = usuarioRepository;
            _segundoFARepository = segundoFARepository;
        }
        public async Task<Result<ResponseModelDto>> Handle(GenerarSecretoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string issuer = "eshop";
                var usuarioEntity = await _usuarioRepository.BuscarPorIdPersonaAsync(request.GenerarSecretoDto.IdPersona);

                if (usuarioEntity is null)
                    return Result<ResponseModelDto>.Failure(new ResponseModelDto("Usuario no encontrado con el idPersona proporcionado."), System.Net.HttpStatusCode.BadRequest);

                string base32Secret = Base32Encoding.ToString(KeyGeneration.GenerateRandomKey(40));

                var segundoFAEntity = new SegundoFAEntity()
                {
                    Activo = 0,
                    Contrasenia = base32Secret,
                    IdUsuario = usuarioEntity.IdUsuario
                };
                await _segundoFARepository.RegistrarAsync(segundoFAEntity);


                string label = $"{issuer}:{usuarioEntity.Nombre}";
                string issuerParam = HttpUtility.UrlEncode(issuer);
                string accountParam = HttpUtility.UrlEncode(usuarioEntity.Nombre);

                string otpauthUri =
                    $"otpauth://totp/{label}?secret={base32Secret}&issuer={issuerParam}&algorithm=SHA512&digits=6&period=30";
                return Result<ResponseModelDto>.Success(new ResponseModelDto(datos: otpauthUri));
            }
            catch (Exception ex)
            {
                return Result<ResponseModelDto>.Failure(new ResponseModelDto(ex.Message), System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
