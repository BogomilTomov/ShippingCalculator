using ShippingCalculator.Models;

namespace ShippingCalculator.Services;

public interface IParcelPriceProcessor
{
    public decimal GetLowestPrice(ParcelData packageData);
}