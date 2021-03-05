﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
    public class RealEstatesController : ControllerBase
    {
        private readonly IRealEstateRepository _realEstateRepository;

        public RealEstatesController( IRealEstateRepository realEstateRepository)
        {
            _realEstateRepository = realEstateRepository;
        }

        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK,typeof(RealEstateDto))]
        public IEnumerable<RealEstateDto> Get()
        {
            var realEstate = _realEstateRepository.Get();
            return realEstate;
        }


        //[SwaggerResponse(HttpStatusCode.NotFound,typeof(string))]
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
    }
}
