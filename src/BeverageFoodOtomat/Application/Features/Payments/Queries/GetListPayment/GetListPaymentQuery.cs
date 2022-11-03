using Application.Features.Payments.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Payments.Queries.GetListPayment;

public class GetListPaymentQuery : IRequest<PaymentListModel>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; set; }
    public string CacheKey => "Payments-list";
    public TimeSpan? SlidingExpiration { get; set; }

    public class GetListPaymentQueryHandler : IRequestHandler<GetListPaymentQuery, PaymentListModel>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public GetListPaymentQueryHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<PaymentListModel> Handle(GetListPaymentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Payment> Payments = await _paymentRepository.GetListAsync(include:
                                                                          c => c.Include(c => c.Beverage)
                                                                              .Include(c => c.Customer)
                                                                              .Include(c=>c.Food)
                                                                              .Include(c=>c.PaymentType)
                                                                              ,
                                                                          index: request.PageRequest.Page,
                                                                          size: request.PageRequest.PageSize
                                      );
            PaymentListModel mappedPaymentListPayment = _mapper.Map<PaymentListModel>(Payments);
            return mappedPaymentListPayment;
        }
    }
}