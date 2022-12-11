using FluentValidation;
using ShippingCalculator.Calculators;
using ShippingCalculator.Models;

namespace ShippingCalculator.CourierProviders;

public interface ICourierProviderFactory
{
    ICourierProvider CreateCourierProvider();
    IParcelCalculator CreateDimensionCalculator();
    IParcelCalculator CreateWeightCalculator();
    AbstractValidator<ParcelData> CreateProviderValidator();
}