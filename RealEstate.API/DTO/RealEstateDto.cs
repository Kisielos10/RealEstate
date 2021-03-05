using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
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
        public BuildingType Type { get; set; }
        public int YearBuilt { get; set; }
        public decimal PricePerMeter { get; set; }
        public AddressDto Address { get; set; }
        //TODO w statystykach wyliczanie price per meter + testy do tego
        //TODO ErrorDto spróbuj w chociaz jednym endpoincie zwrócić 
        //[SwaggerResponse(HttpStatusCode.NotFound, typeof(ErrorResponseDto), Description = "Store or job not found")]
    }

    public class AddressDto
    {
        public string PostalCode { get; set; }
        public string StreetName { get; set; }
        public int BuildingNumber { get; set; }
        public int? ApartmentNumber { get; set; }
    }
}
