using ShippingCalculator.Models;

namespace ShippingCalculator.Calculators;

public class WeightCalculator : IParcelCalculator
{
    private readonly List<Tier> _tiers;

    public WeightCalculator(List<Tier> tiers)
    {
        _tiers = tiers;
    }

    public decimal Calculate(ParcelData parcelData)
    {
        var tier = _tiers.FirstOrDefault(x => parcelData.Weight <= x.UpperBound && parcelData.Weight > x.LowerBand);

        return tier?.Price ?? 0;
    }
}
