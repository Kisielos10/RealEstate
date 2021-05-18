using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.DTO
{
    public class CreateRealEstateDto
    {
        [Required] 
        public decimal Price { get; set; }
        [Required] 
        public decimal Area { get; set; }
        [Required] 
        public BuildingType? Type { get; set; }
        public AddressDto Address { get; set; }
        public int YearBuilt { get; set; }


    }
}
