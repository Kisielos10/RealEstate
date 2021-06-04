using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using RealEstate.API.DTO;

namespace RealEstate.API.Validators
{
    public class CreateRealEstateNoteDtoValidator : AbstractValidator<CreateRealEstateNoteDto>
    {
        public CreateRealEstateNoteDtoValidator()
        {
            RuleFor(realEstateNote => realEstateNote.CreatedAt)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now);
            RuleFor(realEstateNote => realEstateNote.Text)
                .NotEmpty();
            RuleFor(realEstateNote => realEstateNote.RealEstateId)
                .NotEmpty();
        }
    }
}
