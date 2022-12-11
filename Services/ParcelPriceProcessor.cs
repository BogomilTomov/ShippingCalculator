using ShippingCalculator.CourierProviders;
using ShippingCalculator.Models;

namespace ShippingCalculator.Services;

public class ParcelPriceProcessor : IParcelPriceProcessor
{
    private readonly IEnumerable<ICourierProvider> _courierProviders;

    public ParcelPriceProcessor(ICourierFactoryManager courierFactoryManager)
    {
        _courierProviders = courierFactoryManager.GetAllCourierProviders();
    }

    public decimal GetLowestPrice(ParcelData parcelData)
    {
        var lowestPrice = decimal.MaxValue;

        foreach (var courierProvider in _courierProviders)
        {
            var price = courierProvider.GetPrice(parcelData);

            if (price < lowestPrice)
            {
                lowestPrice = price;
            }
        }

        return lowestPrice;
    }
}