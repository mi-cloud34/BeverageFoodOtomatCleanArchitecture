
using Application.Features.Customers.Commands.DeleteCustomer;
using Application.Features.Customers.Commands.UpdateCustomer;
using Application.Features.Customers.Dtos;
using Application.Features.Customers.Queries.GetByIdCustomer;
using Application.Features.Customers.Queries.GetListCustomer;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Customers.Commands.CreateCustomer;
using Application.Features.Customers.Models;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdCustomerQuery getByIdBrandQuery)
    {
        CustomerDto result = await Mediator.Send(getByIdBrandQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCustomerQuery getListBrandQuery = new() { PageRequest = pageRequest };
        CustomerListModel result = await Mediator.Send(getListBrandQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCustomerCommand createBrandCommand)
    {
        CreateCustomerDto result = await Mediator.Send(createBrandCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerCommand updateBrandCommand)
    {
        UpdateCustomerDto result = await Mediator.Send(updateBrandCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteCustomerCommand deleteBrandCommand)
    {
        DeleteCustomerDto result = await Mediator.Send(deleteBrandCommand);
        return Ok(result);
    }
}