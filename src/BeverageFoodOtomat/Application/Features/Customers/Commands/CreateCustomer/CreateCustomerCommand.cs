using Application.Features.Customers.Dtos;
using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Commands.CreateCustomer;

public class CreateCustomerCommand : IRequest<CreateCustomerDto>,  ICacheRemoverRequest
{
    public int Id { get; set; }
    public string CustomerName { get; set; }  
    public bool BypassCache { get; }
    public string CacheKey => "Customers-list";
   
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly CustomerBusinessRules _customerBusinessRules;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper,
                                         CustomerBusinessRules customerBusinessRules)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _customerBusinessRules = customerBusinessRules;
        }

        public async Task<CreateCustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer mappedCustomer = _mapper.Map<Customer>(request);
            Customer createdCustomer = await _customerRepository.AddAsync(mappedCustomer);
            CreateCustomerDto createdCustomerDto = _mapper.Map<CreateCustomerDto>(createdCustomer);
            return createdCustomerDto;
        }
    }
}