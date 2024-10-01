using BigFolk.Api.Models.DTO.Genius;
using FluentValidation;

namespace BigFolk.Api.Validators
{
    public class AddGeniusRequestDtoValidator : AbstractValidator<AddGeniusRequestDto>
    {
        public AddGeniusRequestDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(30);
        }
    }
}
