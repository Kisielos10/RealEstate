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
                //.ForMember(dest => dest.Address, opt =>
                //{
                //    //TODO Tego nie wiem jak zrobić
                //    opt.MapFrom(src => CreateMap<RealEstateAddress,AddressDto>());
                //})
                //TODO zaokrągalnie decimal
                //.ForMember(dest => typeof(decimal), opt => opt.ConvertUsing(Math.Round(context,2)))
                .ForMember(dest => dest.PricePerMeter, opt =>
                {
                    opt.PreCondition(src => src.Area > 0);
                    opt.MapFrom(src => src.Price / src.Area);
                });
                //.ReverseMap();
        }
    }
}
