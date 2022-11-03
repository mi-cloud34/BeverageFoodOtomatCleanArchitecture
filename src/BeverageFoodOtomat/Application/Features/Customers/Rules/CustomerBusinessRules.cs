
using Application.Features.Customers.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Customers.Rules;

public class CustomerBusinessRules : BaseBusinessRules
{
    private readonly ICustomerRepository _CustomerRepository;

    public CustomerBusinessRules(ICustomerRepository CustomerRepository)
    {
        _CustomerRepository = CustomerRepository;
    }

    public async Task CustomerIdShouldExistWhenSelected(int id)
    {
        Customer? result = await _CustomerRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(CustomerMessages.CustomerNotExists);
    }

    public async Task CustomerNameCanNotBeDuplicatedWhenInserted(string name)
    {
        IPaginate<Customer> result = await _CustomerRepository.GetListAsync(b => b.CustomerName == name);
        if (result.Items.Any()) throw new BusinessException(CustomerMessages.CustomerNameExists);
    }
}