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
                return BadRequest(new ErrorDto(HttpStatusCode.BadRequest,$"Real Estate Note with id {id} is not valid"));

            var realEstateNote = _realEstateNotes.GetById(id);

            if (realEstateNote == null)
            {
                return NotFound(new ErrorDto(HttpStatusCode.NotFound,$"Real Estate Note with id {id} was not found"));
            }

            return Ok(realEstateNote);
        }
        [SwaggerResponse(HttpStatusCode.NotFound,typeof(ErrorDto))]
        [SwaggerResponse(HttpStatusCode.OK,typeof(RealEstateNoteDto))]
        [HttpGet]
        public ActionResult<List<RealEstateNoteDto>> GetByRealEstateId([FromQuery]int realEstateId)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ErrorDto(HttpStatusCode.BadRequest,$"Real Estate Note with id {realEstateId}  is not valid"));

            var realEstateNotes = _realEstateNotes.GetByRealEstateId(realEstateId);

            if (realEstateNotes == null)
            {
                return NotFound(new ErrorDto(HttpStatusCode.NotFound,$"Real Estate with id {realEstateId} either does not exist or there are no notes attached to this RealEstate"));
            }

            return Ok(realEstateNotes);
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
            if (!ModelState.IsValid)
                return BadRequest(new ErrorDto(HttpStatusCode.BadRequest,$"Real Estate Note with id {createRealEstateNoteDto.RealEstateId} is not valid"));
            if (_realEstateRepository.GetById(createRealEstateNoteDto.RealEstateId) == null)
            {
                return NotFound(new ErrorDto(HttpStatusCode.NotFound,$"Real Estate with id {createRealEstateNoteDto.RealEstateId} was not found"));
            }

            var result = _realEstateNotes.Add(createRealEstateNoteDto);

            return Created(new Uri($"{Request.Path}/{result.Id}",UriKind.Relative) ,result);
        }



    }
}
