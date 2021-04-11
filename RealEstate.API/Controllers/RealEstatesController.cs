using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NSwag.Annotations;
using RealEstate.API.DTO;
using RealEstate.API.Persistence;
using RealEstate.API.Repositiories;
using System.Drawing;
using Microsoft.EntityFrameworkCore.Migrations;
using Image = System.Drawing.Image;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(ErrorDto))]
    public class RealEstatesController : BaseController
    {
        private readonly IRealEstateRepository _realEstateRepository;
        private readonly RealEstateDbContext _context;


        public RealEstatesController(IRealEstateRepository realEstateRepository, RealEstateDbContext context)
        {
            _realEstateRepository = realEstateRepository;
            _context = context;
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
            if (_realEstateRepository.GetById(id) == null)
            {
                return NotFound(new ErrorDto(HttpStatusCode.NotFound,$"Real Estate with {id} id was not found"));
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
                return NotFound(new ErrorDto(HttpStatusCode.NotFound,$"Real Estate with {id} id was not found"));
            }

            _realEstateRepository.Delete(id);

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
        [HttpPost("upload")]
        //public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
        public ActionResult<Guid> UploadImage(List<IFormFile> files)
        {

            foreach(var file in files)
            {
                var img = new Persistence.Image
                {
                    ImageTitle = file.FileName,
                    Suffix = Path.GetExtension(file.FileName)
                };

                var ms = new MemoryStream();
                file.CopyTo(ms);
                img.ImageData = ms.ToArray();

                ms.Close();
                ms.Dispose();

                _context.Images.Add(img);
                _context.SaveChanges();

                return img.Id;
            }

            return Guid.Empty;

        }
        [HttpPost("Retrieve")]
        [SwaggerResponse(HttpStatusCode.OK,typeof(Image))]
        public ActionResult<System.Drawing.Image> RetrieveImage()
        {
            var img = _context.Images.FirstOrDefault(opt => opt.Id == Guid.Empty);

            using var ms = new MemoryStream(img.ImageData);

            var returnImage = Image.FromStream(ms);

            return Ok(returnImage);

        }
    }
}
