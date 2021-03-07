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
                250
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
                200
            };

            yield return new object[]
            {
                new List<RealEstateDto>
                {
                    new RealEstateDto()
                },
                0
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
                5618.59m
            };
        }
    }
}
