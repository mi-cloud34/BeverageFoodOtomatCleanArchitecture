
using Application.Features.Payments.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Payments.Rules;

public class PaymentBusinessRules : BaseBusinessRules
{
    private readonly IPaymentRepository _PaymentRepository;

    public PaymentBusinessRules(IPaymentRepository PaymentRepository)
    {
        _PaymentRepository = PaymentRepository;
    }

    public async Task PaymentIdShouldExistWhenSelected(int id)
    {
        Payment? result = await _PaymentRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(PaymentMessages.PaymentNotExists);
    }
    public async Task PaymentNameCanNotBeDuplicatedWhenInserted(int id)
    {
        IPaginate<Payment> result = await _PaymentRepository.GetListAsync(b => b.CustomerId == id);
        if (result.Items.Any()) throw new BusinessException(PaymentMessages.PaymentNameExists);
    }
   
}