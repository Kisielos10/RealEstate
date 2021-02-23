using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstate.API.DTO;

namespace RealEstate.API.Repositiories
{
    public interface IRealEstateNoteRepository
    {
        RealEstateNoteDto GetById(int i);
        bool Put(RealEstateNoteDto realEstateNoteDto, int id);
        bool Delete(int id);
        RealEstateNoteDto Add(CreateRealEstateNoteDto createRealEstateNoteDto);
    }
}
