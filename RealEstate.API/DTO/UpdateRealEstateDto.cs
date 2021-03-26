using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.DTO
{
    public class UpdateRealEstateDto
    {
        [Range(0,20000000)]
        public decimal Price { get; set; }
        public decimal Area { get; set; }
        public BuildingType Type { get; set; }
        public int YearBuilt { get; set; }
        public decimal PricePerMeter { get; set; }
        public AddressDto Address { get; set; }
    }
}
