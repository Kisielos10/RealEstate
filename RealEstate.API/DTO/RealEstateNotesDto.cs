using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.DTO
{
    public class RealEstateNotesDto
    {
        [Required]
        public string Note { get; set; }
        [Required] 
        public RealEstateDto RealEstateDto { get; set; }
    }
}
