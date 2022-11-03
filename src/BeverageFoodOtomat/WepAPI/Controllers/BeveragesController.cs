
using Application.Features.Beverages.Commands.CreateBeverage;
using Application.Features.Beverages.Commands.DeleteBeverage;
using Application.Features.Beverages.Commands.UpdateBeverage;
using Application.Features.Beverages.Dtos;
using Application.Features.Beverages.Models;
using Application.Features.Beverages.Queries.GetByIdBeverage;
using Application.Features.Beverages.Queries.GetListBeverage;
using Application.Features.BeverageSugarFreeTypes.Commands.CreateBeverageSugarFreeType;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BeveragesController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdBeverageQuery getByIdBrandQuery)
    {
        BeverageDto result = await Mediator.Send(getByIdBrandQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBeverageQuery getListBrandQuery = new() { PageRequest = pageRequest };
        BeverageListModel result = await Mediator.Send(getListBrandQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBeverageCommand createBrandCommand)
    {
        CreateBeverageDto result = await Mediator.Send(createBrandCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBeverageCommand updateBrandCommand)
    {
        UpdateBeverageDto result = await Mediator.Send(updateBrandCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteBeverageCommand deleteBrandCommand)
    {
        DeleteBeverageDto result = await Mediator.Send(deleteBrandCommand);
        return Ok(result);
    }
}