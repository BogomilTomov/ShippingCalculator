namespace ShippingCalculator.CourierProviders;

public class CourierFactoryManager : ICourierFactoryManager
{
    private readonly IEnumerable<ICourierProviderFactory> _factories = new List<ICourierProviderFactory>()
    {
        new Cargo4YouProviderFactory()
    };

    public IEnumerable<ICourierProvider> GetAllCourierProviders()
    {
        return _factories.Select(f => f.CreateCourierProvider());
    }
}