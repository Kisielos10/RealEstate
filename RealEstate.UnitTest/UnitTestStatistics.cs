using System;
using System.Collections.Generic;
using FluentAssertions;
using RealEstate.API.DTO;
using RealEstate.API.Services;
using Xunit;

namespace RealEstate.UnitTest
{
    public class StatisticCalculationTests
    {
        [Fact]
        public void CalculateMeanArea()
        {
            var calculator = new StatisticsCalculator();
            var result = calculator.CalculateMeanArea(new List<RealEstateDto>());
            result.Should().Be((0));
        }
        [Fact]
        public void CalculateMeanAreaForTwoRealEstates()
        {
            var calculator = new StatisticsCalculator();
            var result = calculator.CalculateMeanArea(new List<RealEstateDto>
            {
                new RealEstateDto()
                {
                    Id = 0,
                    Area = 200m,
                    Price = 5000000m
                },
                new RealEstateDto()
                {
                    Id = 1,
                    Area = 300m,
                    Price = 90000000m
                }
            });
            result.Should().Be(250);
        }
        [Fact]
        public void CalculateMeanAreaForThreeRealEstates()
        {
            var calculator = new StatisticsCalculator();
            var result = calculator.CalculateMeanArea(new List<RealEstateDto>
            {
                new RealEstateDto()
                {
                    Id = 0,
                    Area = 123.51m,
                    Price = 5000000m
                },
                new RealEstateDto()
                {
                    Id = 1,
                    Area = 6732.267m,
                    Price = 90000000m
                },
                new RealEstateDto()
                {
                    Id = 2,
                    Area = 9999.9999m,
                    Price = 90000m
                }
            });
            result.Should().Be(5618.59m);
        }
        [Fact]
        public void CalculateMeanAreaNull()
        {
            var calculator = new StatisticsCalculator();
            var result = calculator.CalculateMeanArea(new List<RealEstateDto>
            {
                new RealEstateDto()
                {
                    Id = 0,
                    Price = 5000000m
                }
            });
            result.Should().Be((0));
        }
    }
}
