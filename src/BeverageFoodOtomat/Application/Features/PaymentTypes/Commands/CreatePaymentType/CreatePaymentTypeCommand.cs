using Application.Features.PaymentTypes.Dtos;
using Application.Features.PaymentTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;


namespace Application.Features.PaymentTypes.Commands.CreatePaymentType;

public class CreatePaymentTypeCommand : IRequest<CreatePaymentTypeDto>, ICacheRemoverRequest
{
    public int Id { get; set; }
    public string PaymentTypeName { get; set; }
    public bool BypassCache { get; }
    public string CacheKey => "PaymentTypes-list";

    public class CreatePaymentTypeCommandHandler : IRequestHandler<CreatePaymentTypeCommand, CreatePaymentTypeDto>
    {
        private readonly IPaymentTypeRepository _paymentTypeRepository;
        private readonly IMapper _mapper;
        private readonly PaymentTypeBusinessRules _paymentTypeBusinessRules;

        public CreatePaymentTypeCommandHandler(IPaymentTypeRepository paymentTypeRepository, IMapper mapper,PaymentTypeBusinessRules paymentTypeBusinessRules
                                       )
        {
            _paymentTypeRepository = paymentTypeRepository;
            _mapper = mapper;
            _paymentTypeBusinessRules = paymentTypeBusinessRules;
        }

        public async Task<CreatePaymentTypeDto> Handle(CreatePaymentTypeCommand request, CancellationToken cancellationToken)
        {
           // await _paymentTypeBusinessRules.PaymentTypeNameCanNotBeDuplicatedWhenInserted(request.PaymentTypeName);
            PaymentType mappedPaymentType = _mapper.Map<PaymentType>(request);
            PaymentType createdPaymentType = await _paymentTypeRepository.AddAsync(mappedPaymentType);
            CreatePaymentTypeDto createdPaymentTypeDto = _mapper.Map<CreatePaymentTypeDto>(createdPaymentType);
            return createdPaymentTypeDto;
        }
    }
}