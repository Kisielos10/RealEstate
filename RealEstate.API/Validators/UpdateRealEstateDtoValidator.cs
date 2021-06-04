using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using RealEstate.API.DTO;

namespace RealEstate.API.Validators
{
    public class UpdateRealEstateDtoValidator : AbstractValidator<UpdateRealEstateDto>
    {
        public UpdateRealEstateDtoValidator()
        {
            RuleFor(realEstate => realEstate.Price)
                .NotNull().WithMessage("The {PropertyName} is required");
            RuleFor(realEstate => realEstate.Area)
                .NotEmpty();
            RuleFor(realEstate => realEstate.YearBuilt)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("The {PropertyName} is required")
                .GreaterThan(DateTime.MinValue.Year).WithMessage("The {PropertyName} is a wrong value");
            RuleFor(realEstate => realEstate.Address).SetValidator(new RealEstateAddressValidator());
            RuleFor(realEstate => realEstate.Type)
                .IsInEnum().WithMessage("{PropertyName} has a range of values which does not include {PropertyValue}");
        }
    }
}
