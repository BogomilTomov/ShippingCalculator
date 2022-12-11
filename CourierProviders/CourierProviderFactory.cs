using ShippingCalculator.Calculators;
using ShippingCalculator.Validators;

namespace ShippingCalculator.CourierProviders;

public class CourierProviderFactory : ICourierProviderFactory
{

    public IEnumerable<ICourierProvider> GetAllCourierProviders()
    {
        return new List<ICourierProvider>()
        {
            CreateCargo4YouProvider()
        };
    }

    public ICourierProvider CreateCargo4YouProvider()
    {
        var dimensionTiers = new List<Tier>()
        {
            new Tier() { LowerBand = 0, UpperBound = 1000, Price = 10 },
            new Tier() { LowerBand = 1000,  UpperBound = 2000, Price = 20 }
        };
        var weightTiers = new List<Tier>()
        {
            new Tier() { LowerBand = 0, UpperBound = 2, Price = 15 },
            new Tier() { LowerBand = 2, UpperBound = 15, Price = 18 },
            new Tier() { LowerBand = 15, UpperBound = 20, Price = 35 }
        };

        var dimensionCalculator = new DimensionCalculator(dimensionTiers);
        var weightCalculator = new WeightCalculator(weightTiers);
        var packageDataValidator = new Cargo4YouProviderValidator();

        return new Cargo4YouProvider(dimensionCalculator, weightCalculator, packageDataValidator);
    }

    public ICourierProvider CreateCourierProvider2()
    {
        throw new NotImplementedException();
    }


    public ICourierProvider CreateCourierProvider3()
    {
        throw new NotImplementedException();
    }
}