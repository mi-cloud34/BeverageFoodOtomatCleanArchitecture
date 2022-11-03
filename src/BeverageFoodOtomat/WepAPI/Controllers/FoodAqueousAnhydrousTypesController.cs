
using Application.Features.FoodAqueousAnhydrousTypes.Commands.DeleteFoodAqueousAnhydrousType;
using Application.Features.FoodAqueousAnhydrousTypes.Commands.UpdateFoodAqueousAnhydrousType;
using Application.Features.FoodAqueousAnhydrousTypes.Dtos;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Application.Features.FoodAqueousAnhydrousTypes.Commands.CreateFoodAqueousAnhydrousType;
using Application.Features.FoodAqueousAnhydrousTypes.Queries.GetListFoodAqueousAnhydrousType;
using Application.Features.FoodAqueousAnhydrousTypes.Models;
using Application.Features.FoodAqueousAnhydrousTypes.Queries.GetByIdFoodAqueousAnhydrousType;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FoodAqueousAnhydrousTypesController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdFoodAqueousAnhydrousTypesQuery getByIdBrandQuery)
    {
        FoodAqueousAnhydrousTypeDto result = await Mediator.Send(getByIdBrandQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFoodAqueousAnhydrousTypeQuery getListBrandQuery = new() { PageRequest = pageRequest };
        FoodAqueousAnhydrousTypesListModel result = await Mediator.Send(getListBrandQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateFoodAqueousAnhydrousTypeCommand createBrandCommand)
    {
        CreateFoodAqueousAnhydrousTypeDto result = await Mediator.Send(createBrandCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFoodAqueousAnhydrousTypeCommand updateBrandCommand)
    {
        UpdateFoodAqueousAnhydrousTypeDto result = await Mediator.Send(updateBrandCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteFoodAqueousAnhydrousTypeCommand deleteBrandCommand)
    {
        DeleteFoodAqueousAnhydrousTypeDto result = await Mediator.Send(deleteBrandCommand);
        return Ok(result);
    }
}