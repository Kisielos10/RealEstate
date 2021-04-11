using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RealEstate.API.DTO;

namespace RealEstate.API.Repositiories
{
    public interface IRealEstateRepository
    {
        List<RealEstateDto> Get();
        List<RealEstateDto> Get(Expression<Func<Persistence.RealEstate,bool>> filterExpression);
        RealEstateDto GetById(int id);
        //TODO czy może lepiej nie zwracać tylko id?
        RealEstateDto Add(CreateRealEstateDto createRealEstateDto);
        RealEstateDto Update(UpdateRealEstateDto updateRealEstateDto, int id);
        void Delete(int id);

    }
}
