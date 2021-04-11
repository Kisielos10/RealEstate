using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NSwag;
using RealEstate.API.DTO;
using RealEstate.API.Persistence;

namespace RealEstate.API.Infrastructure
{
    public class RealEstateProfile : Profile
    {
        public RealEstateProfile()
        {
            CreateMap<Persistence.RealEstate, RealEstateDto>()
                .ForMember(dest => dest.BuildingType, opt => opt.MapFrom(src => src.BuildingType))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.RealEstateAddress))
                .ForMember(dest => dest.PricePerMeter, opt =>
                {
                    opt.PreCondition(src => src.Area > 0);
                    opt.MapFrom(src => decimal.Round(src.Price / src.Area, 2));
                });
                //.ReverseMap();
        }
    }
}
