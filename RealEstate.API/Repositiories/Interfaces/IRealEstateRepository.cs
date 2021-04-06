using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using RealEstate.API.DTO;

namespace RealEstate.API.Repositiories
{
    public interface IRealEstateRepository
    {
        List<RealEstateDto> Get();
        RealEstateDto GetById(int id);
        //TODO czy może lepiej nie zwracać tylko id?
        RealEstateDto Add(CreateRealEstateDto createRealEstateDto);
        RealEstateDto Update(UpdateRealEstateDto updateRealEstateDto, int id);
        RealEstateDto Delete(int id);
    }
}
