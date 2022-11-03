
using Application.Features.Payments.Commands.DeletePayment;
using Application.Features.Payments.Commands.UpdatePayment;
using Application.Features.Payments.Dtos;
using Application.Features.Payments.Queries.GetByIdPayment;
using Application.Features.Payments.Queries.GetListPayment;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Payments.Commands.CreatePayment;
using Application.Features.Payments.Models;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdPaymentQuery getByIdBrandQuery)
    {
        PaymentDto result = await Mediator.Send(getByIdBrandQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPaymentQuery getListBrandQuery = new() { PageRequest = pageRequest };
        PaymentListModel result = await Mediator.Send(getListBrandQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreatePaymentCommand createBrandCommand)
    {
        CreatePaymentDto result = await Mediator.Send(createBrandCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePaymentCommand updateBrandCommand)
    {
        UpdatePaymentDto result = await Mediator.Send(updateBrandCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeletePaymentCommand deleteBrandCommand)
    {
        DeletePaymentDto result = await Mediator.Send(deleteBrandCommand);
        return Ok(result);
    }
}