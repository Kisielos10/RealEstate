using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.DTO;
using RealEstate.API.Persistence;

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
                    Area = 400.30m,
                    Price = 5000000m,
                    YearBuilt = 2000,
                    BuildingType = 0,
                    RealEstateAddress = new RealEstateAddress()
                    {
                        ApartmentNumber = 2,
                        BuildingNumber = 13,
                        PostalCode = "66-446",
                        StreetName = "Piłsudzkiego"
                    }
                },
                new Persistence.RealEstate()
                {
                    Area = 50000.30m,
                    Price = 90000000m,
                    YearBuilt = 2000
                },
                new Persistence.RealEstate()
                {
                    Area = 30.21m,
                    Price = 50000m,
                    YearBuilt = 2000
                }
            };

            foreach (var r in realEstates)
            {
                context.RealEstates.Add(r);
            }

            context.SaveChanges();

            var realEstateNotes = new[]
            {
                new RealEstateNote()
                {
                    Text = "Beautiful 3 bedroom, 2 bathroom, single story home with mountain views in the community of Victorville! Enjoy an open floor plan with an inviting fireplace and an open kitchen. The kitchen offers white cabinetry, black appliances, and views to the back yard. The primary bedroom features carpet flooring, a walk-in closet, and dual sinks in the primary bathroom. Additional property features include sliding doors to the covered outdoor patio, a 2 car garage, and no HOA. Convenient to area shops, schools, and easy access to major freeways!",
                    CreatedAt = DateTime.Now,
                    RealEstateId = 0
                },
                new RealEstateNote()
                {
                    Text = "Has an additional bedroom at entrance for those young adults that want there privacy, Owner will give credit for carpet and paint, Needs TLC  Enjoy those holidays with the chimney! This wont last! Take Advantage!",
                    CreatedAt = DateTime.Today,
                    RealEstateId = 1
                },
                new RealEstateNote()
                {
                    Text = "There is a large master bedroom upstairs with a large walk in closet.  The master bath also features a Jacuzzi tub.  New carpeting was recently installed and fresh interior paint throughout.",
                    CreatedAt = DateTime.Parse("5/1/2008 8:30:52 AM", System.Globalization.CultureInfo.InvariantCulture),
                    RealEstateId = 2
                }
            };

            foreach (var n in realEstateNotes)
            {
                context.RealEstateNotes.Add(n);
            }

            context.SaveChanges();
        }
    }
}
