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
        [MemberData(nameof(RealEstateTestDataGenerator.GetRealEstateFromDataGenerator),MemberType = typeof(RealEstateTestDataGenerator))]
        public void CalculateMeanAreaTheory(List<RealEstateDto> realEstate,ExpectedStatistics expectedStatistics)
        {
            var result = _calculator.CalculateMeanArea(realEstate);
            result.Should().Be(expectedStatistics.ExpectedMeanArea);
        }

        [Fact]
        public void CalculateMeanAreaNull()
        {
            Action act = () => _calculator.CalculateMeanArea(null);

            act.Should().Throw<ArgumentNullException>().Which.Message.Should().Contain("This value should not be null");
        }

        [Theory]
        [MemberData(nameof(RealEstateTestDataGenerator.GetRealEstateFromDataGenerator),MemberType = typeof(RealEstateTestDataGenerator))]
        public void CalculateMeanPricePerMeter(List<RealEstateDto> realEstate,ExpectedStatistics expectedStatistics)
        {
            var result = _calculator.CalculateMeanPricePerMeter(realEstate);
            result.Should().Be(expectedStatistics.ExpectedMeanPricePerMeter);
        }
        [Fact]
        public void CalculateMeanPricePerMeterNull()
        {
            Action act = () => _calculator.CalculateMeanPricePerMeter(null);

            act.Should().Throw<ArgumentNullException>().Which.Message.Should().Contain("This value should not be null");
        }
        [Fact]
        public void CalculateMeanPricePerMeterZero()
        {
            Action act = () => _calculator.CalculateMeanPricePerMeter(new List<RealEstateDto>
            {
                new RealEstateDto
                {
                    Area = 0,
                    Price = 10
                }
            });

            act.Should().Throw<ArgumentOutOfRangeException>().Which.Message.Should().Contain("Area and Price should have a valid value");
        }
    }
}
