using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstate.API.DTO;

namespace RealEstate.API.Repositiories
{
    public interface IRealEstateNotes
    {
        List<RealEstateNotesDto> Get();
    }
}
