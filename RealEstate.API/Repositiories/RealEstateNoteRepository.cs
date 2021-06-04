using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using AutoMapper;
using RealEstate.API.DTO;
using RealEstate.API.Persistence;

namespace RealEstate.API.Repositiories
{
    public class RealEstateNoteRepository : IRealEstateNoteRepository
    {

        private readonly RealEstateDbContext _context;
        private readonly IMapper _mapper;

        public RealEstateNoteRepository(RealEstateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<RealEstateNoteDto> GetByRealEstateId(int id)
        {
            var listOfRealEstateNote = _context.RealEstateNotes.Where(opt => opt.RealEstateId == id).ToList();

            var mappedRealEstateNotes = _mapper.Map<List<RealEstateNote>, List<RealEstateNoteDto>>(listOfRealEstateNote);

            return mappedRealEstateNotes;
        }

        public void Delete(int id)
        {
            var realEstateNote = _context.RealEstateNotes.FirstOrDefault(x => x.Id == id);

            if (realEstateNote == null)
            {
                throw new ArgumentException($"Real Estate with id {id} does not exist");
            }

            _context.RealEstateNotes.Remove(realEstateNote);

            _context.SaveChanges();
        }

        public RealEstateNoteDto GetById(int id)
        {
            var realEstateNote = _context.RealEstateNotes.FirstOrDefault(opt => opt.Id == id);

            var mappedRealEstateNote = _mapper.Map<RealEstateNote,RealEstateNoteDto>(realEstateNote);

            return mappedRealEstateNote;
        }

        public RealEstateNoteDto Add(CreateRealEstateNoteDto createRealEstateNoteDto)
        {

            var realEstateNoteDto = new RealEstateNote
            {
                CreatedAt = createRealEstateNoteDto.CreatedAt ?? DateTime.Now, 
                RealEstateId = createRealEstateNoteDto.RealEstateId,
                Text = createRealEstateNoteDto.Text
            };

            _context.RealEstateNotes.Add(realEstateNoteDto);

            _context.SaveChanges();

            var mappedRealEstateNoteDto = _mapper.Map<RealEstateNoteDto>(realEstateNoteDto);

            return mappedRealEstateNoteDto;
        }
    }
}
