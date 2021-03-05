using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using System.Transactions;
using NSwag.Annotations;
using RealEstate.API.DTO;
using RealEstate.API.Repositiories;
using RealEstate.API.Services;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IRealEstateRepository _realEstateRepository;
        private readonly StatisticsCalculator _calculator;

        public StatisticsController(IRealEstateRepository realEstateRepository, StatisticsCalculator calculator)
        {
            _realEstateRepository = realEstateRepository;
            _calculator = calculator;
        }


        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK,typeof(StatisticDto))]
        //TODO przypomnieć o walidacji dokumentacji swaggera
        public ActionResult<StatisticDto> Get([FromQuery(Name = "type")]BuildingType? buildingType, [FromQuery(Name = "area")]decimal? area, [FromQuery(Name = "yearBuilt")]int? yearBuilt)
        {
            Func<RealEstateDto,bool> predicate = null;
            if (area.HasValue)
            {
                predicate += dto => dto.Area > area;
            }
            else if (yearBuilt.HasValue)
            {
                predicate += dto => dto.YearBuilt > yearBuilt;
            }
            else if (buildingType.HasValue)
            {
                predicate = dto => dto.Type == buildingType.Value;
            }
            else
            {
                predicate = dto => true;
            }
            var condition = _realEstateRepository.Get().Where(predicate);
            var meanArea = _calculator.CalculateMeanArea(condition.ToList());
            var pricePerMeter = _calculator.CalculatePricePerMeter(condition.ToList());
            return new StatisticDto(meanArea,pricePerMeter);
        }

    }
}
