using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using NSwag.Annotations;
using RealEstate.API.DTO;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : BaseController
    {
        [SwaggerResponse(HttpStatusCode.OK,typeof(string))]
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "healthy";
        }
    }
}
