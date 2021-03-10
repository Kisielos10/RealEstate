using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RealEstate.API.DTO;

namespace RealEstate.UnitTest
{
    internal class RealEstateTestDataGenerator 
    {
        public static IEnumerable<object[]> GetRealEstateFromDataGenerator()
        {
            yield return new object[]
            {
                new List<RealEstateDto>
                {
                    new RealEstateDto
                    {
                        Id = 0,
                        Area = 200m,
                        Price = 5000000m
                    },
                    new RealEstateDto
                    {
                        Id = 1,
                        Area = 300m,
                        Price = 90000000m
                    }
                },
                new ExpectedStatistics(250,190000m)
            };

            yield return new object[]
            {
                new List<RealEstateDto>
                {
                    new RealEstateDto
                    {
                        Id = 0,
                        Area = 200m,
                        Price = 5000000m
                    },
                },
                new ExpectedStatistics(200,25000)
            };

            yield return new object[]
            {
                new List<RealEstateDto>
                {
                    new RealEstateDto()
                },
                new ExpectedStatistics(0, 0)
            };

            yield return new object[]
            {
                new List<RealEstateDto>
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
                },
                new ExpectedStatistics(5618.59m, 5641.39m)
            };
        }
    }
}
