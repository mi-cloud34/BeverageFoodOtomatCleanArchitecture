
using Application.Features.Customers.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Queries.GetByIdCustomer;

public class GetByIdCustomerQuery : IRequest<CustomerDto>
{
    public int Id { get; set; }

    public class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQuery, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
      
        public GetByIdCustomerQueryHandler(ICustomerRepository customerRepository,
                                        IMapper mapper)
        {
            _customerRepository = customerRepository;
          
            _mapper = mapper;
        }


        public async Task<CustomerDto> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
        {
           
            Customer? Customer = await _customerRepository.GetAsync(m => m.Id == request.Id);
            CustomerDto CustomerDto = _mapper.Map<CustomerDto>(Customer);
            return CustomerDto;
        }
    }
}