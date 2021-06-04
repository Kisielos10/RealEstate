using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using RealEstate.API.DTO;

namespace RealEstate.API.Persistence
{
    public class RealEstate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Area { get; set; }
        public int? YearBuilt { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PricePerMeter { get; set; }
        public BuildingType BuildingType { get; set; }

        public RealEstateAddress RealEstateAddress { get; set; }
        public ICollection<RealEstateNote> RealEstateNotes { get; set; }
    }
}
