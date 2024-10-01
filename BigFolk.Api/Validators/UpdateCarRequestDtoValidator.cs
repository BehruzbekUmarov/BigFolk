using BigFolk.Api.Models.DTO.Car;
using FluentValidation;

namespace BigFolk.Api.Validators
{
    public class UpdateCarRequestDtoValidator : AbstractValidator<UpdateCarRequestDto>
    {
        public UpdateCarRequestDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(30);
            RuleFor(x => x.State).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Type).NotEmpty().MaximumLength(10);
        }
    }
}
