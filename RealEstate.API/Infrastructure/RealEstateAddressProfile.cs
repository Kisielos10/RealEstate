using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RealEstate.API.DTO;
using RealEstate.API.Persistence;

namespace RealEstate.API.Infrastructure
{
    public class RealEstateAddressProfile : Profile
    {
        public RealEstateAddressProfile()
        {
            CreateMap<RealEstateAddress, AddressDto>();
            CreateMap<AddressDto, RealEstateAddress>();
        }
    }
}
