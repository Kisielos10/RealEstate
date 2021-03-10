using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstate.API.DTO;

namespace RealEstate.API.Services
{
    public class StatisticsCalculator
    {
        public decimal CalculateMeanArea(List<RealEstateDto> realEstate)
        {
            if (realEstate == null)
            {
                throw new ArgumentNullException("This value should not be null");
            }

            if (realEstate.Count == 0)
            {
                return 0;
            }

            var sum = realEstate.Sum(x => x.Area);

            var result = sum / realEstate.Count;

            return decimal.Round(result, 2);
        }

        public decimal CalculateMeanPricePerMeter(List<RealEstateDto> realEstate)
        {
            if (realEstate == null)
            {
                throw new ArgumentNullException("This value should not be null");
            }

            if (realEstate.All(dto => dto.Price == 0))
            {
                return 0;
            }

            if (realEstate.Any(dto => dto.Area <= 0 ) || realEstate.Any(dto => dto.Price <= 0 ))
            {
                throw new ArgumentOutOfRangeException("Area and Price should have a valid value");
            }

            var sumPrice = realEstate.Sum(x => x.Price);
            var sumArea = realEstate.Sum(x => x.Area);

            var result = sumPrice / sumArea;

            return decimal.Round(result,2);
        }
        
    }
}
