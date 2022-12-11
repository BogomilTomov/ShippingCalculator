using ShippingCalculator.Models;

namespace ShippingCalculator.CourierProviders;

public interface ICourierFactoryManager
{
    public IEnumerable<ICourierProvider> GetAllProviderFactories();
}