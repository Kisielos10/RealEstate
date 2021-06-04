using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RealEstate.API.DTO;
using RealEstate.API.Persistence;
using RealEstate.API.Validators;

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

        public int Add(CreateRealEstateDto createRealEstateDto)
        {
            var realEstate = new Persistence.RealEstate()
            {
                Price = createRealEstateDto.Price,
                Area = createRealEstateDto.Area,
                BuildingType = createRealEstateDto.Type ?? BuildingType.Other,
                YearBuilt = createRealEstateDto.YearBuilt,
                //todo problem tutaj
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

            //var mappedRealEstate = _mapper.Map<RealEstateDto>(realEstate);

            return realEstate.Id;
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
            var mappedRealEstate = _mapper.Map<List<Persistence.RealEstate>,List<RealEstateDto>>(realEstate);

            return mappedRealEstate;
        }

        public List<RealEstateDto> Get(Expression<Func<Persistence.RealEstate, bool>> filterExpression)
        {
            var realEstate = _context.RealEstates.Where(filterExpression).ToList();

            var mappedRealEstate = _mapper.Map<List<Persistence.RealEstate>,List<RealEstateDto>>(realEstate);

            return mappedRealEstate;
        }

        public RealEstateDto GetById(int id)
        {
            var realEstate = _context.RealEstates.FirstOrDefault(opt => opt.Id == id);

            var mappedRealEstate = _mapper.Map<RealEstateDto>(realEstate);

            return mappedRealEstate;
        }

        public RealEstateDto Update(UpdateRealEstateDto updateRealEstateDto, int id)
        {
            var realEstateToUpdate = _context.RealEstates.FirstOrDefault(opt => opt.Id == id);

            if (realEstateToUpdate == null) return null;

            realEstateToUpdate.Price = updateRealEstateDto.Price ?? realEstateToUpdate.Price;
            realEstateToUpdate.RealEstateAddress = _mapper.Map<RealEstateAddress>(updateRealEstateDto.Address) ?? realEstateToUpdate.RealEstateAddress;
            realEstateToUpdate.Area = updateRealEstateDto.Area ?? realEstateToUpdate.Area;
            realEstateToUpdate.BuildingType = updateRealEstateDto.Type ?? realEstateToUpdate.BuildingType;
            realEstateToUpdate.YearBuilt = updateRealEstateDto.YearBuilt ?? realEstateToUpdate.YearBuilt;

            _context.SaveChanges();

            var mappedRealEstate = _mapper.Map<RealEstateDto>(realEstateToUpdate);

            return mappedRealEstate;

        }
    }
}
