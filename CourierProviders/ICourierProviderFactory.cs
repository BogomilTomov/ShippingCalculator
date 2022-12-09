namespace ShippingCalculator.CourierProviders;

public interface ICourierProviderFactory
{
    IEnumerable<ICourierProvider> GetAllCourierProviders();
}