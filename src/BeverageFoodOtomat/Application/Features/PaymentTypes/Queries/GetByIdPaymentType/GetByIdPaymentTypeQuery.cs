using Application.Features.PaymentTypes.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PaymentTypes.Queries.GetByIdPaymentType;

public class GetByIdPaymentTypeQuery : IRequest<PaymentTypeDto>
{
    public int Id { get; set; }

    public class GetByIdPaymentTypeQueryHandler : IRequestHandler<GetByIdPaymentTypeQuery, PaymentTypeDto>
    {
        private readonly IPaymentTypeRepository _paymentTypeRepository;
        private readonly IMapper _mapper;
    
        public GetByIdPaymentTypeQueryHandler(IPaymentTypeRepository paymentTypeRepository,
                                        IMapper mapper)
        {
            _paymentTypeRepository = paymentTypeRepository;
         
            _mapper = mapper;
        }


        public async Task<PaymentTypeDto> Handle(GetByIdPaymentTypeQuery request, CancellationToken cancellationToken)
        {
          
            PaymentType? PaymentType = await _paymentTypeRepository.GetAsync(b => b.Id == request.Id);
            PaymentTypeDto PaymentTypeDto = _mapper.Map<PaymentTypeDto>(PaymentType);
            return PaymentTypeDto;
        }
    }
}