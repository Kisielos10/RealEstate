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

        public StatisticDto(decimal area)
        {
            Area = area;
        }
    }
}
