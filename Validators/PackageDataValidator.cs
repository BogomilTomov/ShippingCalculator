using FluentValidation;
using ShippingCalculator.Models;

namespace ShippingCalculator.Validators;
public class PackageDataInputValidator : AbstractValidator<ParcelData>
{
    public void DataValidator()
    {
        // Validation rules for the package data
        RuleFor(x => x.Width)
            .GreaterThan(0)
            .WithMessage("Width must be greater than 0");

        RuleFor(x => x.Height)
            .GreaterThan(0)
            .WithMessage("Height must be greater than 0");

        RuleFor(x => x.Depth)
            .GreaterThan(0)
            .WithMessage("Depth must be greater than 0");

        RuleFor(x => x.Weight)
            .GreaterThan(0)
            .WithMessage("Weight must be greater than 0");
    }
}