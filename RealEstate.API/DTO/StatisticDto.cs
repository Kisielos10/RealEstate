using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.DTO
{
    public class StatisticDto
    {
        [Required]
        public decimal Area { get; set; }
        [Required]
        public decimal PricePerMeter { get; set; }

        public StatisticDto(decimal area, decimal pricePerMeter)
        {
            Area = area;
            PricePerMeter = pricePerMeter;
        }
    }
}
