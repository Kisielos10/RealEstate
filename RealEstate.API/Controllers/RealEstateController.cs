using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstate.API.DTO;
using RealEstate.API.Repositiories;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        private readonly IRealEstateRepository _realEstateRepository;

        public RealEstateController( IRealEstateRepository realEstateRepository)
        {
            _realEstateRepository = realEstateRepository;
        }

        [HttpGet]
        public IEnumerable<RealEstateDto> Get()
        {
            var realEstate = _realEstateRepository.Get();
            return realEstate;
        }

        [HttpGet("{id}")]
        public RealEstateDto GetById(int id)
        {
            var realEstate = _realEstateRepository.GetById(id);

            if (realEstate == null)
            {
                return null;
            }

            return realEstate;
        }
    }
}
