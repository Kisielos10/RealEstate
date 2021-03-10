using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using RealEstate.API.DTO;

namespace RealEstate.API.Controllers
{
    [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(string))]
    public class BaseController : ControllerBase
    {

    }
}
