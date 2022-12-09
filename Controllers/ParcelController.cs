using Microsoft.AspNetCore.Mvc;
using shippingApp.Models;

namespace shippingApp.Controllers;

[ApiController]
[Route("[controller]")]
public class ParcelController : ControllerBase
{
    private readonly IParcelPriceProcessor _parcelPriceProcessor;

    public ParcelController(IParcelPriceProcessor parcelPriceProcessor)
    {
        _parcelPriceProcessor = parcelPriceProcessor;
    }

    [HttpPost]
    public IActionResult CalculatePrice([FromBody] PackageData data)
    {
        var validator = new PackageDataValidator();
        var validationResult = validator.Validate(data);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var price = _parcelPriceProcessor.GetLowestPrice(data);
        return Ok(price);
    }
}
