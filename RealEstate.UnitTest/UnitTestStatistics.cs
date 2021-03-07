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
        public void CalculateMeanAreaTheory(List<RealEstateDto> realEstate,decimal expectedMeanArea)
        {
            var result = _calculator.CalculateMeanArea(realEstate);
            result.Should().Be(expectedMeanArea);
        }

        [Fact]
        public void CalculateMeanAreaNull()
        {
            Action act = () => _calculator.CalculateMeanArea(null);

            act.Should().Throw<ArgumentNullException>().Which.Message.Should().Contain("This value should not be null");
        }

        [Theory]
        [MemberData(nameof(RealEstateTestDataGenerator.GetRealEstateFromDataGenerator),MemberType = typeof(RealEstateTestDataGenerator))]
        public void CalculateMeanPricePerMeter(List<RealEstateDto> realEstate,decimal expectedMeanPricePerMeter)
        {
            var result = _calculator.CalculateMeanArea(realEstate);
            result.Should().Be(expectedMeanPricePerMeter);
        }
    }
}
