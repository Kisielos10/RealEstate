using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RealEstate.API.DTO;
using RealEstate.API.Persistence;

namespace RealEstate.API.Infrastructure
{
    public class RealEstateNoteProfile : Profile
    {
        public RealEstateNoteProfile()
        {
            CreateMap<RealEstateNote, RealEstateNoteDto>();

        }
    }
}
