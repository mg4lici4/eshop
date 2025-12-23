using AutoMapper;
using EShop.Application.Dtos.Origen;
using EShop.Domain.Entities;

namespace EShop.Application.Common.Profiles
{
    public class OrigenProfile : Profile
    {
        public OrigenProfile()
        {
            CreateMap<OrigenEntity, OrigenDto>();
        }
    }
}
