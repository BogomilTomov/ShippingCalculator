﻿using Microsoft.AspNetCore.Mvc;
using ShippingCalculator.Models;
using ShippingCalculator.Services;
using ShippingCalculator.Validators;

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
    public IActionResult CalculatePrice([FromBody] ParcelData data)
    {
        var validator = new ParcelDataInputValidator();
        var validationResult = validator.Validate(data);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var price = _parcelPriceProcessor.GetLowestPrice(data);

        return Ok(price);
    }
}
