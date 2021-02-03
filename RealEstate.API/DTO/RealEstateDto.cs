using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
//TODO rozwinąć sensowne atrybuty
namespace RealEstate.API.DTO
{
    /// <summary>
    /// cokolwiek
    /// </summary>
    public class RealEstateDto
    {
        [Required]
        public int Id { get; set; }
        [Range(0,20000000)]
        public decimal Price { get; set; }
        public decimal Area { get; set; }
        public AddressDto Address { get; set; }
        public FactsAndFeatures FactsAndFeatures { get; set; }
    }

    public class FactsAndFeatures
    {
        public enum BuildingType
        {
            SingleFamilyHome,
            MultiFamilyHome,
            Condominium,
            Lot
        }

        public BuildingType Type { get; set; }
        public int YearBuilt { get; set; }
        public decimal PricePerMeter { get; set; }

    }

    public class AddressDto
    {
        public string PostalCode { get; set; }
        public string StreetName { get; set; }
        public int BuildingNumber { get; set; }
        public int? ApartmentNumber { get; set; }
    }
}
