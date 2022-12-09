using ShippingCalculator.Models;

namespace ShippingCalculator.CourierProviders;

public interface ICourierProvider
{
    public decimal GetPrice(ParcelData parcelData);
}