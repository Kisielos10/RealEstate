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
            //TODO *zabezpiecz się przed nullem* chyba zrobiłem
            var result = realEstate.Sum(x => x.Area);
            if (result == 0)
            {
                return 0;
            }
            result /= realEstate.Count;

            return decimal.Round(result, 2);
        }
        
    }
}
