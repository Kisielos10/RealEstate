using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstate.API.DTO;

namespace RealEstate.API.Repositiories
{
    public class RealEstateRepository : IRealEstateRepository
    {
        private static List<RealEstateDto> realEstateDtos = new List<RealEstateDto>()
        {
            new RealEstateDto()
            {
                Id = 0,
                Area = 400.30m,
                Price = 5000000m
            },
            new RealEstateDto()
            {
                Id = 1,
                Area = 50000.30m,
                Price = 90000000m
            },
            new RealEstateDto()
            {
                Id = 2,
                Area = 30.21m,
                Price = 50000m
            }
        };

        public List<RealEstateDto> Get()
        {
            return realEstateDtos;
        }

        public RealEstateDto GetById(int i)
        {
            var realEstate = realEstateDtos.FirstOrDefault(x => x.Id == i);

            return realEstate;
        }

        public RealEstateDto Update(UpdateRealEstateDto realEstate, int id)
        {
            var realEstateToUpdate = realEstateDtos.FirstOrDefault(x => x.Id.Equals(id));

            realEstateToUpdate.Price = realEstate.Price ?? realEstateToUpdate.Price;
            realEstateToUpdate.Address = realEstate.Address ?? realEstateToUpdate.Address;
            realEstateToUpdate.Area = realEstate.Area ?? realEstateToUpdate.Area;
            realEstateToUpdate.Type = realEstate.Type ?? realEstateToUpdate.Type;
            realEstateToUpdate.YearBuilt = realEstate.YearBuilt ?? realEstateToUpdate.YearBuilt;
            

            return realEstateToUpdate;
        }
    }
}
