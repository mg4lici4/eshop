using AutoMapper;
using EShop.Application.Dtos.Usuario;
using EShop.Domain.Entities;

namespace EShop.Application.Common.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<RegistrarUsuarioDto, UsuarioEntity>();
        }
    }
}
