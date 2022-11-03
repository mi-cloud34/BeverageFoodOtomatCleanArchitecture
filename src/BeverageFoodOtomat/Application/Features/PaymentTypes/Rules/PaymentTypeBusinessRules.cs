
using Application.Features.PaymentTypes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.PaymentTypes.Rules;

public class PaymentTypeBusinessRules : BaseBusinessRules
{
    private readonly IPaymentTypeRepository _PaymentTypeRepository;

    public PaymentTypeBusinessRules(IPaymentTypeRepository PaymentTypeRepository)
    {
        _PaymentTypeRepository = PaymentTypeRepository;
    }

    public async Task PaymentTypeIdShouldExistWhenSelected(int id)
    {
        PaymentType? result = await _PaymentTypeRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(PaymentTypeMessages.PaymentTypeNotExists);
    }

    public async Task PaymentTypeNameCanNotBeDuplicatedWhenInserted(string name)
    {
        IPaginate<PaymentType> result = await _PaymentTypeRepository.GetListAsync(b => b.PaymentTypeName == name);
        if (result.Items.Any()) throw new BusinessException(PaymentTypeMessages.PaymentTypeNameExists);
    }
}