using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RealEstate.API.DTO
{
    public class ErrorDto
    {
        public HttpStatusCode StatusCode {get;set;}
        public string Message { get; set; }

        public ErrorDto(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
