using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
//TODO rozwinąć RealEstateController i RealEstateDto(Id) sensowne atrybuty i property w kontrolerze get by id 
//TODO całkiem nowy controller na notatki związane z real estatem i do tego nowy DTO
namespace RealEstate.API.DTO
{
    /// <summary>
    /// cokolwiek
    /// </summary>
    public class RealEstateDto
    {
        [Range(0,20000000)]
        public decimal Price { get; set; }
        public decimal Area { get; set; }
        public AddressDto Address { get; set; }
    }

    public class AddressDto
    {
        public string PostalCode { get; set; }
        public string StreetName { get; set; }
        public int BuildingNumber { get; set; }
        public int? ApartmentNumber { get; set; }
    }
}
