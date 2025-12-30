using EShop.Application.Common;
using EShop.Application.Dtos;
using EShop.Application.Interfaces.Repositories;
using MediatR;

namespace EShop.Application.Features.Login.Queries
{
    public class ValidarOtpHandler : IRequestHandler<ValidarOtpQuery, Result<ResponseModelDto>>
    {
        private readonly ISegundoFARepository _segundoFARepository;
        public ValidarOtpHandler(ISegundoFARepository segundoFARepository)
        {
            _segundoFARepository = segundoFARepository;
        }
        public async Task<Result<ResponseModelDto>> Handle(ValidarOtpQuery request, CancellationToken cancellationToken)
        {
            var segundoFAEntity = await _segundoFARepository.BuscarPorIdUsuario(request.ValidarOtpDto.IdUsuario);
            if (segundoFAEntity is null)
                return Result<ResponseModelDto>.Failure(new ResponseModelDto("Ocurrio un error con los datos proporcionados."),System.Net.HttpStatusCode.BadRequest);

            
            var secretBytes = OtpNet.Base32Encoding.ToBytes(segundoFAEntity.Contrasenia);

            var totp = new OtpNet.Totp(secretBytes, step: 30, mode: OtpNet.OtpHashMode.Sha512);
            bool valid = totp.VerifyTotp(request.ValidarOtpDto.Otp, out _, new OtpNet.VerificationWindow(1, 1));
            return Result<ResponseModelDto>.Success(new ResponseModelDto(valid));
        }
    }
}
