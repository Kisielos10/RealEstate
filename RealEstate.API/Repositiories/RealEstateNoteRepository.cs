﻿using System;
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
        private static List<RealEstateNoteDto> realEstateNotes = new List<RealEstateNoteDto>()
        {
            new RealEstateNoteDto()
            {
                Id = 1,
                Text = "Beautiful 3 bedroom, 2 bathroom, single story home with mountain views in the community of Victorville! Enjoy an open floor plan with an inviting fireplace and an open kitchen. The kitchen offers white cabinetry, black appliances, and views to the back yard. The primary bedroom features carpet flooring, a walk-in closet, and dual sinks in the primary bathroom. Additional property features include sliding doors to the covered outdoor patio, a 2 car garage, and no HOA. Convenient to area shops, schools, and easy access to major freeways!",
                CreatedAt = DateTime.Now,
                RealEstateId = 0
            },
            new RealEstateNoteDto()
            {
                Id = 2,
                Text = "Has an additional bedroom at entrance for those young adults that want there privacy, Owner will give credit for carpet and paint, Needs TLC  Enjoy those holidays with the chimney! This wont last! Take Advantage!",
                CreatedAt = DateTime.Today,
                RealEstateId = 1
            },
            new RealEstateNoteDto()
            {
                Id = 3,
                Text = "There is a large master bedroom upstairs with a large walk in closet.  The master bath also features a Jacuzzi tub.  New carpeting was recently installed and fresh interior paint throughout.",
                CreatedAt = DateTime.Parse("5/1/2008 8:30:52 AM", System.Globalization.CultureInfo.InvariantCulture),
                RealEstateId = 2
            }
        };

        private readonly RealEstateDbContext _context;
        private readonly IMapper _mapper;

        public RealEstateNoteRepository(RealEstateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool Delete(int id)
        {
            var realEstateNote = realEstateNotes.FirstOrDefault(x => x.Id == id);

            return realEstateNotes.Remove(realEstateNote);
        }

        public RealEstateNoteDto GetById(int id)
        {
            ////TODO nie wiem czemu nie mogęzrobić FirstOrDefault na RealEstateNotes
            ////var realEstateNote = _context.RealEstates.FirstOrDefault(opt => opt.RealEstateNotes.FirstOrDefault(note => note.Id == id));

            //var realEstateNote = _context.RealEstateNotes.RealEstateId;

            //var mappedRealEstateNote = _mapper.Map<RealEstateNoteDto>(realEstateNote);

            //return mappedRealEstateNote;

            //var realEstateNote = _context.RealEstateNotes;

            //var mappedRealEstateNote = _mapper.Map<RealEstateDto>(realEstateNote);

            return null;
        }

        public RealEstateNoteDto Add(CreateRealEstateNoteDto createRealEstateNoteDto)
        {
            int id;
            if (!realEstateNotes.Any())
            {
                id = 1;
            }
            else
            {
                id = realEstateNotes.Max(x => x.Id) + 1;
            }

            var realEstateNoteDto = new RealEstateNoteDto
            {
                CreatedAt = createRealEstateNoteDto.CreatedAt ?? DateTime.Now, 
                Id = id,
                RealEstateId = createRealEstateNoteDto.RealEstateId,
                Text = createRealEstateNoteDto.Text
            };
            realEstateNotes.Add(realEstateNoteDto);

            return realEstateNoteDto;
        }
    }
}
