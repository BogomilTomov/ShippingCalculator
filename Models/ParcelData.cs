namespace ShippingCalculator.Models
{
    public class ParcelData
    {
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Depth { get; set; }
        public decimal Weight { get; set; }
        public decimal Volume => Width * Height * Depth;
    }
}