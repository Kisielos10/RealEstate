using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        //[ResponseCache(Duration =  60, Location = ResponseCacheLocation.Any)]
        public ActionResult<RealEstateDto> Get()
        {
            var realEstate = _realEstateRepository.Get();
            return Ok(realEstate);
        }
        //TODO dodawać i usuwać zdjęcia do real estate blob storage
        //TODO dodaj lepsze cache'owanie (server side)
        //TODO oData
        /// <summary>
        /// Just a regular get endpoint
        /// <see cref="RealEstateDto"/>
        /// </summary>
        /// <param name="id">bla bla bla</param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.NotFound, typeof(ErrorDto))]
        [SwaggerResponse(HttpStatusCode.OK,typeof(RealEstateDto))]
        [HttpGet("{id}")]
        public ActionResult<RealEstateDto> GetById(int id)
        {
            var realEstate = _realEstateRepository.GetById(id);

            if (realEstate == null)
            {
                return NotFound(new ErrorDto(HttpStatusCode.NotFound,$"Real Estate with {id} id was not found"));
            }

            return Ok(realEstate);
        }

        [SwaggerResponse(HttpStatusCode.NotFound, typeof(ErrorDto))]
        [SwaggerResponse(HttpStatusCode.Created, typeof(RealEstateDto))]
        [HttpPut("{id}")]
        public ActionResult<RealEstateDto> Update([FromBody] UpdateRealEstateDto updateRealEstateDto,
            [FromRoute] int id)
        {
            //TODO dodać walidację id bo ta jest brzydka
            if (_realEstateRepository.GetById(id) == null)
            {
                return NotFound(new ErrorDto(HttpStatusCode.NotFound,$"Real Estate with {id} id was not found"));
            }

            var result = _realEstateRepository.Update(updateRealEstateDto, id);

            return CreatedAtAction("update",new {id = result.Id},result);
        }

        [SwaggerResponse(HttpStatusCode.NotFound,typeof(ErrorDto))]
        [SwaggerResponse(HttpStatusCode.NoContent,typeof(RealEstateDto))]
        [HttpDelete("{id}")]
        public ActionResult<RealEstateDto> Delete([FromRoute]int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ErrorDto(HttpStatusCode.BadRequest,$"Real Estate Note with {id} id is not valid"));

            var realEstate = _realEstateRepository.Delete(id);

            if (realEstate == null)
            {
                return NotFound(new ErrorDto(HttpStatusCode.NotFound,$"Real Estate with {id} id was not found"));
            }

            return NoContent();

        }
        [SwaggerResponse(HttpStatusCode.Created,typeof(RealEstateDto))]
        [HttpPost]
        public ActionResult<RealEstateDto> Post([FromBody] CreateRealEstateDto createRealEstateDto )
        {
            var result = _realEstateRepository.Add(createRealEstateDto);

            return Created(new Uri($"{Request.Path}/{result.Id}",UriKind.Relative) ,result);
        }

        [SwaggerResponse(HttpStatusCode.OK,typeof(object))]
        [HttpPost("Upload")]
        public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
        {
            var size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.GetTempFileName();

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // Process uploaded files

            return Ok(new { count = files.Count, size });
        }
    }
}
