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
    //TODO Dodać DTO z error message kod 500 ?stack trace?
    //TODO ASP Web Api Middleware

    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateNotesController : ControllerBase
    {
        private readonly IRealEstateNoteRepository _realEstateNotes;

        public RealEstateNotesController( IRealEstateNoteRepository realEstateNotes, ILogger logger)
        {
            _realEstateNotes = realEstateNotes;
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
        [SwaggerResponse(HttpStatusCode.NoContent,typeof(RealEstateNoteDto))]
        [HttpDelete("{id}")]
        public ActionResult<RealEstateNoteDto> Delete([FromRoute]int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var realEstateNote = _realEstateNotes.Delete(id);

            if (realEstateNote)
            {
                return NoContent();
            }

            return NotFound();

        }

        [HttpPost]
        public ActionResult<RealEstateNoteDto> Post([FromBody] RealEstateNoteDto realEstateNoteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var realEstateNote = _realEstateNotes.Post(realEstateNoteDto);

            if (realEstateNote)
            {
                return BadRequest();
            }

            return NotFound();
        }
        
    }
}
