using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using RealEstate.API.DTO;
using RealEstate.API.Repositiories;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(ErrorDto))]
    public class ImageController : BaseController
    {
        //todo co chciałbym jeszcze zrobić
        //SOLID (moge zrobić samemu?)
        //Dependency Injection Life Cycles
        //Log Framework np Serilog albo Nlog
        //Test mocking np Moq
        //Integration Testing
        //Czy warto się uczyć wzorców projektowych? (CQRS na pewno ale jakieś builder albo singleton?)
        //Allow users to get all apartments and filter by status (Available, Reserved, NotAvailable) and other criteria
        //Azure
        //JWT
        //ASP.NET Identity
        //Może jakiś framework do cache'ingu

        private readonly IRealEstateRepository _realEstateRepository;
        private readonly RealEstateDbContext _context;

        public ImageController(IRealEstateRepository realEstateRepository, RealEstateDbContext context)
        {
            _realEstateRepository = realEstateRepository;
            _context = context;
        }

        [SwaggerResponse(HttpStatusCode.OK,typeof(object))]
        [SwaggerResponse(HttpStatusCode.BadRequest,typeof(ErrorDto))]
        [HttpPost]
        public ActionResult<int> UploadImage(IFormFile file)
        {
            string[] permittedExtensions = { ".jpg", ".jpeg",".png" };

            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
            {
                return BadRequest(new ErrorDto(HttpStatusCode.BadRequest,"The file cannot be uploaded because the format is not supported "));
            }

            const double fileSizeLimit = 4194304;

            if (file.Length > fileSizeLimit)
            {
                return BadRequest(new ErrorDto(HttpStatusCode.BadRequest,"The file cannot be uploaded because it's size is greater than 4MB "));
            }

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

            return Ok(img.Id);
        }


        [SwaggerResponse(HttpStatusCode.OK, typeof(object))]
        [SwaggerResponse(HttpStatusCode.NotFound, typeof(ErrorDto))]
        //[ResponseCache(Duration =  120, Location = ResponseCacheLocation.Client)]
        [HttpGet ("{id}")]
        public IActionResult GetImage(int id)
        {
           var image = _context.Images.FirstOrDefault(i => i.Id == id);

            if (image == null)
            {
                return NotFound(new ErrorDto(HttpStatusCode.NotFound,$"Image with id {id} was not found"));
            }
            var imageData = image.ImageData;
            var contentType = "image/" + image.ImageTitle;
            var response = File(imageData,contentType);

            return response;
        }
    }
}
