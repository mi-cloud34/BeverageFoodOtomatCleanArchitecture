
using Application.Features.Foods.Commands.DeleteFood;
using Application.Features.Foods.Commands.UpdateFood;
using Application.Features.Foods.Dtos;
using Application.Features.Foods.Queries.GetByIdFood;
using Application.Features.Foods.Queries.GetListFood;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Foods.Commands.CreateFood;
using Application.Features.Foods.Models;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FoodsController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdFoodQuery getByIdBrandQuery)
    {
        FoodDto result = await Mediator.Send(getByIdBrandQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFoodQuery getListBrandQuery = new() { PageRequest = pageRequest };
        FoodListModel result = await Mediator.Send(getListBrandQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateFoodCommand createBrandCommand)
    {
        CreateFoodDto result = await Mediator.Send(createBrandCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFoodCommand updateBrandCommand)
    {
        UpdateFoodDto result = await Mediator.Send(updateBrandCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteFoodCommand deleteBrandCommand)
    {
        DeleteFoodDto result = await Mediator.Send(deleteBrandCommand);
        return Ok(result);
    }
}