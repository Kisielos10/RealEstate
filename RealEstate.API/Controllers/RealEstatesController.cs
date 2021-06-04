using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;
using System.Net;
using NSwag.Annotations;
using RealEstate.API.DTO;
using RealEstate.API.Repositiories;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(ErrorDto))]
    public class RealEstatesController : BaseController
    {
        private readonly IRealEstateRepository _realEstateRepository;

        public RealEstatesController(IRealEstateRepository realEstateRepository)
        {
            _realEstateRepository = realEstateRepository;
        }


        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK,typeof(RealEstateDto))]
        [ResponseCache(Duration =  60, Location = ResponseCacheLocation.Any)]
        public ActionResult<RealEstateDto> Get()
        {
            var realEstate = _realEstateRepository.Get();
            return Ok(realEstate);
        }
        //TODO oData graphql
        [HttpGet("{filterExpression}")]
        [SwaggerResponse(HttpStatusCode.OK,typeof(RealEstateDto))]
        //[ResponseCache(Duration =  60, Location = ResponseCacheLocation.Any)]
        public ActionResult<RealEstateDto> GetByExpression( Expression<Func<Persistence.RealEstate, bool>> filterExpression)
        {
            var realEstate = _realEstateRepository.Get(filterExpression);
            return Ok(realEstate);
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="id">Real Estate Id</param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.NotFound, typeof(ErrorDto))]
        [SwaggerResponse(HttpStatusCode.OK,typeof(RealEstateDto))]
        [HttpGet("{id:int}")]
        //[ResponseCache(Duration =  60, Location = ResponseCacheLocation.Any)]
        public ActionResult<RealEstateDto> GetById(int id)
        {
            var realEstate = _realEstateRepository.GetById(id);

            if (realEstate == null)
            {
                return NotFound(new ErrorDto(HttpStatusCode.NotFound,$"Real Estate with id {id} was not found"));
            }

            return Ok(realEstate);
        }

        [SwaggerResponse(HttpStatusCode.NotFound, typeof(ErrorDto))]
        [SwaggerResponse(HttpStatusCode.Created, typeof(RealEstateDto))]
        [HttpPut("{id}")]
        public ActionResult<RealEstateDto> Update([FromBody] UpdateRealEstateDto updateRealEstateDto,
            [FromRoute] int id)
        {
            if (_realEstateRepository.GetById(id) == null)
            {
                return NotFound(new ErrorDto(HttpStatusCode.NotFound,$"Real Estate with id {id} was not found"));
            }

            var result = _realEstateRepository.Update(updateRealEstateDto, id);

            return CreatedAtAction("update",new {id = result.Id},result);
        }

        [SwaggerResponse(HttpStatusCode.NotFound,typeof(ErrorDto))]
        [SwaggerResponse(HttpStatusCode.NoContent,typeof(string))]
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)
        {
            if (_realEstateRepository.GetById(id) == null)
            {
                return NotFound(new ErrorDto(HttpStatusCode.NotFound,$"Real Estate with id {id} was not found"));
            }

            _realEstateRepository.Delete(id);

            return NoContent();

        }
        [SwaggerResponse(HttpStatusCode.Created,typeof(RealEstateDto))]
        [HttpPost]
        //todo czasami nie mogę w swaggerze kliknąć "execute"
        public ActionResult<RealEstateDto> Post([FromBody] CreateRealEstateDto createRealEstateDto )
        {
            var result = _realEstateRepository.Add(createRealEstateDto);

            return Created(new Uri($"{Request.Path}/{result}",UriKind.Relative) ,result);
        }
    }
}
