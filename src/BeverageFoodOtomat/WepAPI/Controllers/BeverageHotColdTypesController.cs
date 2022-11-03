
using Application.Features.BeverageHotColdTypes.Commands.CreateBeverageHotColdType;
using Application.Features.BeverageHotColdTypes.Commands.DeleteBeverageHotColdType;
using Application.Features.BeverageHotColdTypes.Commands.UpdateBeverageHotColdType;
using Application.Features.BeverageHotColdTypes.Dtos;
using Application.Features.BeverageHotColdTypes.Models;
using Application.Features.BeverageHotColdTypes.Queries.GetByIdBeverageHotColdType;
using Application.Features.BeverageHotColdTypes.Queries.GetListBeverageHotColdType;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BeverageHotColdTypesController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdBeverageHotColdTypeQuery getByIdBrandQuery)
    {
        BeverageHotColdTypeDto result = await Mediator.Send(getByIdBrandQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBeverageHotColdTypeQuery getListBrandQuery = new() { PageRequest = pageRequest };
        BeverageHotColdTypeListModel result = await Mediator.Send(getListBrandQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBeverageHotColdTypeCommand createBrandCommand)
    {
        CreateBeverageHotColdTypeDto result = await Mediator.Send(createBrandCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBeverageHotColdTypeCommand updateBrandCommand)
    {
        UpdateBeverageHotColdTypeDto result = await Mediator.Send(updateBrandCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteBeverageHotColdTypeCommand deleteBrandCommand)
    {
        DeleteBeverageHotColdTypeDto result = await Mediator.Send(deleteBrandCommand);
        return Ok(result);
    }
}