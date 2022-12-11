using FluentValidation;
using ShippingCalculator.Calculators;
using ShippingCalculator.Models;
using ShippingCalculator.Validators;

namespace ShippingCalculator.CourierProviders;

public class Cargo4YouProviderFactory : ICourierProviderFactory
{
    public ICourierProvider CreateCourierProvider()
    {
        var dimensionCalculator = CreateDimensionCalculator();
        var weightCalculator = CreateWeightCalculator();
        var packageDataValidator = CreateProviderValidator();

        return new Cargo4YouProvider(dimensionCalculator, weightCalculator, packageDataValidator);
    }

    public IParcelCalculator CreateDimensionCalculator()
    {
        var dimensionTiers = new List<Tier>()
        {
            new Tier() { LowerBand = 0, UpperBound = 1000, Price = 10 },
            new Tier() { LowerBand = 1000,  UpperBound = 2000, Price = 20 }
        };

        return new WeightCalculator(dimensionTiers);
    }

    public IParcelCalculator CreateWeightCalculator()
    {
        var weightTiers = new List<Tier>()
        {
            new Tier() { LowerBand = 0, UpperBound = 2, Price = 15 },
            new Tier() { LowerBand = 2, UpperBound = 15, Price = 18 },
            new Tier() { LowerBand = 15, UpperBound = 20, Price = 35 }
        };

        return new WeightCalculator(weightTiers);
    }

    public AbstractValidator<ParcelData> CreateProviderValidator()
    {
        return new Cargo4YouProviderValidator();
    }
}