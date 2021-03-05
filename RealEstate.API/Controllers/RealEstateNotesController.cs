using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NSwag.Annotations;
using RealEstate.API.DTO;
using RealEstate.API.Repositiories;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateNotesController : ControllerBase
    {
        private readonly IRealEstateNoteRepository _realEstateNotes;
        private readonly IRealEstateRepository _realEstateRepository;

        public RealEstateNotesController( IRealEstateNoteRepository realEstateNotes, IRealEstateRepository realEstateRepository)
        {
            _realEstateNotes = realEstateNotes;
            _realEstateRepository = realEstateRepository;
        }
        [SwaggerResponse(HttpStatusCode.NotFound,typeof(string))]
        [SwaggerResponse(HttpStatusCode.OK,typeof(RealEstateNoteDto))]
        [HttpGet("{id}")]
        public ActionResult<RealEstateNoteDto> GetById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var realEstateNote = _realEstateNotes.GetById(id);

            if (realEstateNote == null)
            {
                return NotFound();
            }

            return Ok(realEstateNote);
        }

        [SwaggerResponse(HttpStatusCode.NotFound,typeof(string))]
        [SwaggerResponse(HttpStatusCode.NoContent,typeof(string))]
        [HttpDelete("{id}")]
        public ActionResult<RealEstateNoteDto> Delete([FromRoute]int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Upewnij się, że wszystkie wymagane zmienne zostały wprowadzone");

            var realEstateNote = _realEstateNotes.Delete(id);

            if (realEstateNote)
            {
                return NoContent();
            }

            return NotFound();

        }

        [SwaggerResponse(HttpStatusCode.Created,typeof(CreateRealEstateNoteDto))]
        [SwaggerResponse(HttpStatusCode.BadRequest,typeof(string))]
        [SwaggerResponse(HttpStatusCode.NotFound,typeof(string))]
        [HttpPost]
        public ActionResult<RealEstateNoteDto> Post([FromBody] CreateRealEstateNoteDto createRealEstateNoteDto )
        {
            //IValidatableObject 
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            if (_realEstateRepository.Get().Any(x => x.Id == createRealEstateNoteDto.RealEstateId))
            {
                return NotFound("The note is not connected to any Real Estate");
            }

            var result = _realEstateNotes.Add(createRealEstateNoteDto);

            return Created(new Uri($"{Request.Path}/{result.Id}",UriKind.Relative) ,result);
        }
        
    }
}
