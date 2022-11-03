
using Application.Features.Payments.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Payments.Queries.GetByIdPayment;

public class GetByIdPaymentQuery : IRequest<PaymentDto>
{
    public int Id { get; set; }

    public class GetByIdPaymentQueryHandler : IRequestHandler<GetByIdPaymentQuery, PaymentDto>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
      
        public GetByIdPaymentQueryHandler(IPaymentRepository paymentRepository,
                                        IMapper mapper)
        {
            _paymentRepository = paymentRepository;
          
            _mapper = mapper;
        }


        public async Task<PaymentDto> Handle(GetByIdPaymentQuery request, CancellationToken cancellationToken)
        {
           
            Payment? Payment = await _paymentRepository.GetAsync(m => m.Id == request.Id);
            PaymentDto PaymentDto = _mapper.Map<PaymentDto>(Payment);
            return PaymentDto;
        }
    }
}