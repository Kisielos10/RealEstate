using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.DTO;

namespace RealEstate.API
{
    public class DbInitializer
    {
        public static void Initialize(RealEstateDbContext context)
        {
            context.Database.EnsureCreated();


            if (context.RealEstates.Any())
            {
                return;
            }

            var realEstates = new[]
            {
                new Persistence.RealEstate()
                {
                    Id = 0,
                    Area = 400.30m,
                    Price = 5000000m,
                    PricePerMeter = 200m,
                    YearBuilt = 2000
                },
                new Persistence.RealEstate()
                {
                    Id = 1,
                    Area = 50000.30m,
                    Price = 90000000m,
                    PricePerMeter = 200m,
                    YearBuilt = 2000
                },
                new Persistence.RealEstate()
                {
                    Id = 2,
                    Area = 30.21m,
                    Price = 50000m,
                    PricePerMeter = 200m,
                    YearBuilt = 2000
                }
            };
            foreach (var r in realEstates)
            {
                context.RealEstates.Add(r);
            }

            context.SaveChanges();
        }
    }
}
