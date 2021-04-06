using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace RealEstate.API.DTO
{
    public class RealEstateDto
    {
        [Required]
        public int Id { get; set; }
        [Range(0,20000000)]
        public decimal Price { get; set; }
        public decimal Area { get; set; }
        public BuildingType BuildingType { get; set; }
        public int YearBuilt { get; set; }
        public decimal PricePerMeter { get; set; }
        public AddressDto Address { get; set; }
        public List<Uri> Files { get; set; }
    }

    public class AddressDto
    {
        public string PostalCode { get; set; }
        public string StreetName { get; set; }
        public int BuildingNumber { get; set; }
        public int? ApartmentNumber { get; set; }
    }
}
