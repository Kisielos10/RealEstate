using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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

        public RealEstatesController( IRealEstateRepository realEstateRepository)
        {
            _realEstateRepository = realEstateRepository;
        }

        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK,typeof(RealEstateDto))]
        [ResponseCache(Duration =  60, Location = ResponseCacheLocation.Any)]
        public IEnumerable<RealEstateDto> Get()
        {
            var realEstate = _realEstateRepository.Get();
            return realEstate;
        }
        //TODO dodawać i usuwać zdjęcia do real estate
        //TODO dodać Put i osobny DTO(gdzie sa sensowne rzeczy) do update'owania real estate
        //TODO dodaj cache'owanie do jednego lub więcej GET'a (będzie widac przy debuggowaniu)
        //TODO zacząć baze
        /// <summary>
        /// Just a regular get endpoint
        /// </summary>
        /// <param name="id"></param>
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

        [SwaggerResponse(HttpStatusCode.BadRequest,typeof(ErrorDto))]
        [SwaggerResponse(HttpStatusCode.NotFound, typeof(ErrorDto))]
        [SwaggerResponse(HttpStatusCode.Created, typeof(RealEstateDto))]
        [HttpPut]
        public ActionResult<RealEstateNoteDto> Update([FromBody] UpdateRealEstateDto updateRealEstateNoteDto,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ErrorDto(HttpStatusCode.BadRequest,$"Real Estate Note with {id} id is not valid"));
            if (updateRealEstateNoteDto == null)
            {
                return NotFound(new ErrorDto(HttpStatusCode.NotFound,$"Real Estate with {id} id was not found"));
            }


            var result = _realEstateRepository.Update(updateRealEstateNoteDto, id);

            return CreatedAtAction("update",new {id = result.Id},result);
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
