using ShippingCalculator.Models;

namespace ShippingCalculator.Calculators;

public interface IParcelCalculator
{
    decimal Calculate(ParcelData packageData);
}