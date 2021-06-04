using FluentValidation;
using RealEstate.API.DTO;
using RealEstate.API.Persistence;

namespace RealEstate.API.Validators
{
    public class RealEstateAddressValidator : AbstractValidator<AddressDto>
    {
        public RealEstateAddressValidator()
        {
            RuleFor(address => address.StreetName)
                .NotNull().WithMessage("The {PropertyName} is required");
            RuleFor(address => address.BuildingNumber)
                .NotNull().WithMessage("The {PropertyName} is required");
            RuleFor(address => address.PostalCode)
                .NotNull().WithMessage("The {PropertyName} is required");;
        }
    }
}
