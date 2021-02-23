using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly StatisticsCalculator _calculator = new StatisticsCalculator();

        public StatisticsController(IRealEstateRepository realEstateRepository)
        {
            _realEstateRepository = realEstateRepository;
        }

        [HttpGet]
        public ActionResult<StatisticDto> Get()
        {
            var stats = _calculator.CalculateMeanArea(_realEstateRepository.Get());
            return new StatisticDto(stats);
        }
        [HttpGet("{type}")]
        public ActionResult<StatisticDto> GetByType(BuildingType buildingType)
        {
            var condition = _realEstateRepository.Get().Where(x => x.Type == buildingType);
            var stats = _calculator.CalculateMeanArea(condition.ToList());
            return new StatisticDto(stats);
        }

    }
}
