using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstate.API.DTO;

namespace RealEstate.API.Repositiories
{
    public class RealEstateNotes : IRealEstateNotes
    {
        private static List<RealEstateNotesDto> realEstateNotes = new List<RealEstateNotesDto>()
        {
            new RealEstateNotesDto()
            {
                Note = "Beautiful 3 bedroom, 2 bathroom, single story home with mountain views in the community of Victorville! Enjoy an open floor plan with an inviting fireplace and an open kitchen. The kitchen offers white cabinetry, black appliances, and views to the back yard. The primary bedroom features carpet flooring, a walk-in closet, and dual sinks in the primary bathroom. Additional property features include sliding doors to the covered outdoor patio, a 2 car garage, and no HOA. Convenient to area shops, schools, and easy access to major freeways!"
            },
            new RealEstateNotesDto()
            {
                Note = "Has an additional bedroom at entrance for those young adults that want there privacy, Owner will give credit for carpet and paint, Needs TLC  Enjoy those holidays with the chimney! This wont last! Take Advantage!"
            },
            new RealEstateNotesDto()
            {
                Note = "There is a large master bedroom upstairs with a large walk in closet.  The master bath also features a Jacuzzi tub.  New carpeting was recently installed and fresh interior paint throughout."
            }
        };
        public List<RealEstateNotesDto> Get()
        {
            return realEstateNotes;
        }
    }
}
