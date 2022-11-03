using Application.Features.Customers.Dtos;
using Application.Services.Repositories;
using AutoMapper;

using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Commands.DeleteCustomer;

public class DeleteCustomerCommand : IRequest<DeleteCustomerDto>, ICacheRemoverRequest
{
    public int Id { get; set; }
    public string CustomerName { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => "Customers-list";
  

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<DeleteCustomerDto> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer mappedCustomer = _mapper.Map<Customer>(request);
            Customer deletedCustomer = await _customerRepository.DeleteAsync(mappedCustomer);
            DeleteCustomerDto deletedCustomerDto = _mapper.Map<DeleteCustomerDto>(deletedCustomer);
            return deletedCustomerDto;
        }
    }
}