using AutoMapper;
using EShop.Application.Dtos.Persona;
using EShop.Domain.Entities;

namespace EShop.Application.Common.Profiles
{
    public class PersonaProfile : Profile
    {
        public PersonaProfile() 
        {
            CreateMap<RegistrarPersonaDto, PersonaEntity>();
        }
    }
}
