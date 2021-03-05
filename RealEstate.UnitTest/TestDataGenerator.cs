using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RealEstate.API.DTO;

namespace RealEstate.UnitTest
{
    class TestDataGenerator : IEnumerable<object[]>
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
                }
            };
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
