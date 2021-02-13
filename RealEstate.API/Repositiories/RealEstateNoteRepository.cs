using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstate.API.DTO;

namespace RealEstate.API.Repositiories
{
    public class RealEstateNoteRepository : IRealEstateNoteRepository
    {
        private static List<RealEstateNoteDto> realEstateNotes = new List<RealEstateNoteDto>()
        {
            new RealEstateNoteDto()
            {
                Id = 0,
                Text = "Beautiful 3 bedroom, 2 bathroom, single story home with mountain views in the community of Victorville! Enjoy an open floor plan with an inviting fireplace and an open kitchen. The kitchen offers white cabinetry, black appliances, and views to the back yard. The primary bedroom features carpet flooring, a walk-in closet, and dual sinks in the primary bathroom. Additional property features include sliding doors to the covered outdoor patio, a 2 car garage, and no HOA. Convenient to area shops, schools, and easy access to major freeways!",
                CreatedAt = DateTime.Now,
                RealEstateId = 0
            },
            new RealEstateNoteDto()
            {
                Id = 1,
                Text = "Has an additional bedroom at entrance for those young adults that want there privacy, Owner will give credit for carpet and paint, Needs TLC  Enjoy those holidays with the chimney! This wont last! Take Advantage!",
                CreatedAt = DateTime.Today,
                RealEstateId = 1
            },
            new RealEstateNoteDto()
            {
                Id = 2,
                Text = "There is a large master bedroom upstairs with a large walk in closet.  The master bath also features a Jacuzzi tub.  New carpeting was recently installed and fresh interior paint throughout.",
                CreatedAt = DateTime.Parse("5/1/2008 8:30:52 AM", System.Globalization.CultureInfo.InvariantCulture),
                RealEstateId = 2
            }
        };

        public bool Delete(int id)
        {
            var realEstateNote = realEstateNotes.FirstOrDefault(x => x.Id == id);

            return realEstateNotes.Remove(realEstateNote);
        }

        public RealEstateNoteDto GetById(int id)
        {
            var realEstateNote = realEstateNotes.FirstOrDefault(x => x.Id == id);

            return realEstateNote;
        }

        public bool Post(RealEstateNoteDto realEstateNoteDto)
        {
            int id;
            if (!realEstateNotes.Any())
            {
                id = 0;
            }
            else
            {
                id = realEstateNotes.Max(x => x.Id) + 1;
            }

            if (realEstateNoteDto.CreatedAt.Year > DateTime.Today.Year || realEstateNoteDto.CreatedAt.Year < 1900)
            {
                return false;
            }
            realEstateNoteDto.Id = id;
            realEstateNotes.Add(realEstateNoteDto);

            return true;
        }

        public bool Put(RealEstateNoteDto realEstateNoteDto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
