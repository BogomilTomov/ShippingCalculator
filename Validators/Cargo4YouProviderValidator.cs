using FluentValidation;
using ShippingCalculator.Models;

namespace ShippingCalculator.Validators;

public class Cargo4YouProviderValidator : AbstractValidator<ParcelData>
{
    public Cargo4YouProviderValidator()
    {
        RuleFor(x => x.Width)
            .LessThan(20)
            .WithMessage("Width must be greater than 20");

        RuleFor(x => x.Volume)
            .LessThan(2000)
            .WithMessage("Height must be greater than 2000");
    }
}