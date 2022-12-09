using FluentValidation;
using ShippingCalculator.Calculators;
using ShippingCalculator.Models;

namespace ShippingCalculator.CourierProviders;

public class Cargo4YouProvider : ICourierProvider
{
    private readonly IParcelCalculator _dimensionCalculator;
    private readonly IParcelCalculator _weightCalculator;
    private readonly AbstractValidator<ParcelData> _packageDataValidator;

    public Cargo4YouProvider(IParcelCalculator dimensionCalculator,
    IParcelCalculator weightCalculator, AbstractValidator<ParcelData> packageDataValidator)
    {
        _dimensionCalculator = dimensionCalculator;
        _weightCalculator = weightCalculator;
        _packageDataValidator = packageDataValidator;
    }

    public decimal GetPrice(ParcelData parcelData)
    {
        var validationResult = _packageDataValidator.Validate(parcelData);
        if (!validationResult.IsValid)
        {
            return 0;
        }

        var priceByDimensions = _dimensionCalculator.Calculate(parcelData);
        var priceByWeight = _weightCalculator.Calculate(parcelData);
        var finalPrice = Math.Max(priceByDimensions, priceByWeight);

        return finalPrice;
    }
}