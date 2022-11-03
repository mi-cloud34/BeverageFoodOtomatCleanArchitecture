
using Application.Features.BeverageSugarFreeTypes.Commands.DeleteBeverageSugarFreeType;
using Application.Features.BeverageSugarFreeTypes.Commands.UpdateBeverageSugarFreeType;
using Application.Features.BeverageSugarFreeTypes.Dtos;
using Application.Features.BeverageSugarFreeTypes.Queries.GetByIdBeverageSugarFreeType;
using Application.Features.BeverageSugarFreeTypes.Queries.GetListBeverageSugarFreeType;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Application.Features.BeverageSugarFreeTypes.Commands.CreateBeverageSugarFreeType;
using Application.Features.BeverageSugarFreeTypes.Models;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BeverageSugarFreeTypesController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdBeverageSugarFreeTypeQuery getByIdBrandQuery)
    {
        BeverageSugarFreeTypeDto result = await Mediator.Send(getByIdBrandQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBeverageSugarFreeTypeQuery getListBrandQuery = new() { PageRequest = pageRequest };
        BeverageSugarFreeTypeListModel result = await Mediator.Send(getListBrandQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBeverageSugarFreeTypeCommand createBrandCommand)
    {
        CreateBeverageSugarFreeTypeDto result = await Mediator.Send(createBrandCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBeverageSugarFreeTypeCommand updateBrandCommand)
    {
        UpdateBeverageSugarFreeTypeDto result = await Mediator.Send(updateBrandCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteBeverageSugarFreeTypeCommand deleteBrandCommand)
    {
        DeleteBeverageSugarFreeTypeDto result = await Mediator.Send(deleteBrandCommand);
        return Ok(result);
    }
}