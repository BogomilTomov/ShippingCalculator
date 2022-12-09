using ShippingCalculator.Models;

namespace ShippingCalculator.Calculators;

public class DimensionCalculator : IParcelCalculator
{
    private readonly List<Tier> _tiers;

    public DimensionCalculator(List<Tier> tiers)
    {
        _tiers = tiers;
    }

    public decimal Calculate(ParcelData parcelData)
    {
        var tier = _tiers.FirstOrDefault(x => parcelData.Volume <= x.UpperBound && parcelData.Volume > x.LowerBand);

        return tier?.Price ?? 0;
    }
}
