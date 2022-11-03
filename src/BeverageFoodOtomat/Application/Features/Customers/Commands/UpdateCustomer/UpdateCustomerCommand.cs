using Application.Features.Customers.Dtos;
using Application.Services.Repositories;
using AutoMapper;

using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommand : IRequest<UpdateCustomerDto>, ICacheRemoverRequest
{

    public int Id { get; set; }
    public string CustomerName { get; set; }
    public bool BypassCache { get; }
    public string CacheKey => "Customers-list";
 

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerDto>
    {
        private ICustomerRepository _customerRepository { get; }
        private IMapper _mapper { get; }

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer mappedCustomer = _mapper.Map<Customer>(request);
            Customer updatedCustomer = await _customerRepository.UpdateAsync(mappedCustomer);
            UpdateCustomerDto updatedCustomerDto = _mapper.Map<UpdateCustomerDto>(updatedCustomer);
            return updatedCustomerDto;
        }
    }
}