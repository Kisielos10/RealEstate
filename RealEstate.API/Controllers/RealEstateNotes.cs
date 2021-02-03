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
    public class RealEstateNotes : ControllerBase
    {
        private readonly IRealEstateNotes _realEstateNotes;

        public RealEstateNotes( IRealEstateNotes realEstateNotes)
        {
            _realEstateNotes = realEstateNotes;
        }
        [HttpGet]
        public IEnumerable<RealEstateNotesDto> Get()
        {
            var realEstateNote = _realEstateNotes.Get();
            return realEstateNote;
        }
    }
}
