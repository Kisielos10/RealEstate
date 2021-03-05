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
        private readonly StatisticsCalculator _calculator;

        public StatisticCalculationTests()
        {
            _calculator = new StatisticsCalculator();
        }

        [Theory]
        [MemberData(nameof(TestDataGenerator.GetRealEstateFromDataGenerator),MemberType = typeof(TestDataGenerator))]
        public void CalculateMeanAreaTheory(List<RealEstateDto> realEstate)
        {
            var result = _calculator.CalculateMeanArea(realEstate);
            result.Should().Be(250);
        }

        [Fact]
        public void CalculateMeanArea()
        {
            var result = _calculator.CalculateMeanArea(new List<RealEstateDto>());
            result.Should().Be(0);
        }
        [Fact]
        public void CalculateMeanAreaForTwoRealEstates()
        {
            var result = _calculator.CalculateMeanArea(new List<RealEstateDto>
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
            var result = _calculator.CalculateMeanArea(new List<RealEstateDto>
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
        public void CalculateMeanAreaNoArea()
        {
            var result = _calculator.CalculateMeanArea(new List<RealEstateDto> 
            {
                new RealEstateDto
                {
                    Id = 0, Price = 5000000m
                }

            });
            result.Should().Be(0);
        }
        [Fact]
        public void CalculateMeanAreaNull()
        {
            Action act = () => _calculator.CalculateMeanArea(null);

            act.Should().Throw<ArgumentNullException>().Which.Message.Should().Contain("This value should not be null");
        }
    }
}
