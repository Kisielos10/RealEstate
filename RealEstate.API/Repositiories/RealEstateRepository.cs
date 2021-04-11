using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RealEstate.API.DTO;
using RealEstate.API.Persistence;

namespace RealEstate.API.Repositiories
{
    public class RealEstateRepository : IRealEstateRepository
    {
        private readonly RealEstateDbContext _context;
        private readonly IMapper _mapper;

        public RealEstateRepository(RealEstateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public RealEstateDto Add(CreateRealEstateDto createRealEstateDto)
        {

            var realEstate = new Persistence.RealEstate()
            {
                Price = createRealEstateDto.Price,
                Area = createRealEstateDto.Area,
                BuildingType = createRealEstateDto.Type ?? BuildingType.Other,
                YearBuilt = createRealEstateDto.YearBuilt,
                //TODO dodać jakąś walidacje
                RealEstateAddress = new RealEstateAddress
                {
                    ApartmentNumber = createRealEstateDto.Address.ApartmentNumber,
                    BuildingNumber = createRealEstateDto.Address.BuildingNumber,
                    PostalCode = createRealEstateDto.Address.PostalCode,
                    StreetName = createRealEstateDto.Address.StreetName
                }
            };

            _context.RealEstates.Add(realEstate);

            _context.SaveChanges();

            var mappedRealEstate = _mapper.Map<RealEstateDto>(realEstate);

            return mappedRealEstate;
        }

        public void Delete(int id)
        {
            var realEstate = _context.RealEstates.FirstOrDefault(x => x.Id == id);

            if (realEstate == null)
            {
                throw new ArgumentException($"Real Estate with id {id} does not exist");
            }

            _context.RealEstates.Remove(realEstate);

            _context.SaveChanges();

        }

        public List<RealEstateDto> Get()
        {
            var realEstate = _context.RealEstates.ToList();
            //Tak trzeba robić
            //todo czemu nie wyświetla building type?
            var mappedRealEstate = _mapper.Map<List<Persistence.RealEstate>,List<RealEstateDto>>(realEstate);

            return mappedRealEstate;
        }

        public List<RealEstateDto> Get(Expression<Func<Persistence.RealEstate, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public RealEstateDto GetById(int id)
        {
            var realEstate = _context.RealEstates.FirstOrDefault(opt => opt.Id == id);

            var mappedRealEstate = _mapper.Map<RealEstateDto>(realEstate);

            return mappedRealEstate;
        }

        public RealEstateDto Update(UpdateRealEstateDto realEstate, int id)
        {
            var realEstateToUpdate = _context.RealEstates.FirstOrDefault(opt => opt.Id == id);

            if (realEstateToUpdate == null) return null;

            realEstateToUpdate.Price = realEstate.Price ?? realEstateToUpdate.Price;
            //todo to trzeba zmapować i zapisać
            //realEstateToUpdate.RealEstateAddress = realEstate.Address ?? realEstateToUpdate.RealEstateAddress;
            realEstateToUpdate.Area = realEstate.Area ?? realEstateToUpdate.Area;
            realEstateToUpdate.BuildingType = realEstate.Type ?? realEstateToUpdate.BuildingType;
            realEstateToUpdate.YearBuilt = realEstate.YearBuilt ?? realEstateToUpdate.YearBuilt;

            _context.SaveChanges();

            var mappedRealEstate = _mapper.Map<RealEstateDto>(realEstateToUpdate);

            return mappedRealEstate;

        }
    }
}
