using BigFolk.Api.Models.DTO.Genius;
using FluentValidation;

namespace BigFolk.Api.Validators
{
    public class UpdateGeniusRequestDtoValidator : AbstractValidator<UpdateGeniusRequestDto>
    {
        public UpdateGeniusRequestDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(30);
        }
    }
}
