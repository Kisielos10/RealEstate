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
    public class RealEstateNotesController : BaseController
    {
        private readonly IRealEstateNoteRepository _realEstateNotes;
        private readonly IRealEstateRepository _realEstateRepository;

        public RealEstateNotesController( IRealEstateNoteRepository realEstateNotes, IRealEstateRepository realEstateRepository)
        {
            _realEstateNotes = realEstateNotes;
            _realEstateRepository = realEstateRepository;
        }
        [SwaggerResponse(HttpStatusCode.NotFound,typeof(ErrorDto))]
        [SwaggerResponse(HttpStatusCode.OK,typeof(RealEstateNoteDto))]
        [HttpGet("{id}")]
        public ActionResult<RealEstateNoteDto> GetById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ErrorDto(HttpStatusCode.BadRequest,$"Real Estate Note with {id} id is not valid"));

            var realEstateNote = _realEstateRepository.GetById(id);

            if (realEstateNote == null)
            {
                return NotFound(new ErrorDto(HttpStatusCode.NotFound,$"Real Estate Note with {id} id was not found"));
            }

            return Ok(realEstateNote);
        }
        [SwaggerResponse(HttpStatusCode.NotFound,typeof(ErrorDto))]
        [SwaggerResponse(HttpStatusCode.OK,typeof(RealEstateNoteDto))]
        [HttpGet("{realEstateId}")]
        public ActionResult<List<RealEstateNoteDto>> GetByRealEstateId([FromQuery]int realEstateId)
        {
            //TODO przerobić żeby nie było błędu
            if (!ModelState.IsValid)
                return BadRequest(new ErrorDto(HttpStatusCode.BadRequest,$"Real Estate Note with {realEstateId} id is not valid"));

            var realEstateNote = _realEstateNotes.GetById(realEstateId);

            if (realEstateNote == null)
            {
                return NotFound(new ErrorDto(HttpStatusCode.NotFound,$"Real Estate Note with {realEstateId} id was not found"));
            }

            return Ok(realEstateNote);
        }

        [SwaggerResponse(HttpStatusCode.NotFound,typeof(ErrorDto))]
        [SwaggerResponse(HttpStatusCode.NoContent,typeof(string))]
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)
        {
            if (_realEstateRepository.GetById(id)== null)
            {
                return NotFound(new ErrorDto(HttpStatusCode.NotFound,$"Real Estate Note with {id} id was not found"));
            }

            _realEstateNotes.Delete(id);

            return NoContent();
        }

        [SwaggerResponse(HttpStatusCode.Created,typeof(CreateRealEstateNoteDto))]
        [SwaggerResponse(HttpStatusCode.BadRequest,typeof(ErrorDto))]
        [SwaggerResponse(HttpStatusCode.NotFound,typeof(ErrorDto))]
        [HttpPost]
        public ActionResult<RealEstateNoteDto> Post([FromBody] CreateRealEstateNoteDto createRealEstateNoteDto )
        {
            //IValidatableObject 
            if (!ModelState.IsValid)
                return BadRequest(new ErrorDto(HttpStatusCode.BadRequest,$"Real Estate Note with {createRealEstateNoteDto.RealEstateId} id is not valid"));
            if (_realEstateRepository.Get().Any(x => x.Id == createRealEstateNoteDto.RealEstateId))
            {
                return NotFound(new ErrorDto(HttpStatusCode.NotFound,$"Real Estate Note with {createRealEstateNoteDto.RealEstateId} id was not found"));
            }

            var result = _realEstateNotes.Add(createRealEstateNoteDto);

            return Created(new Uri($"{Request.Path}/{result.Id}",UriKind.Relative) ,result);
        }



    }
}
