
using Application.Features.Customers.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Customers.Queries.GetListCustomer;

public class GetListCustomerQuery : IRequest<CustomerListModel>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; set; }
    public string CacheKey => "Customers-list";
    public TimeSpan? SlidingExpiration { get; set; }

    public class GetListCustomerQueryHandler : IRequestHandler<GetListCustomerQuery, CustomerListModel>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetListCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerListModel> Handle(GetListCustomerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Customer> Customers = await _customerRepository.GetListAsync(
                                                                          index: request.PageRequest.Page,
                                                                          size: request.PageRequest.PageSize
                                      );
            CustomerListModel mappedCustomerListCustomer = _mapper.Map<CustomerListModel>(Customers);
            return mappedCustomerListCustomer;
        }
    }
}