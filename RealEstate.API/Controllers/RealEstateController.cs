using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstate.API.DTO;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<RealEstateDto> Get()
        {
            List<RealEstateDto> realEstateDtos = new List<RealEstateDto>
            {
                new RealEstateDto()
                {
                    Area = 200.2m
                }
            };
            return realEstateDtos;
        }
    }
}
