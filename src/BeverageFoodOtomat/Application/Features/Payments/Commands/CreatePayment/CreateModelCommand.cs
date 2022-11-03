using Application.Features.Payments.Dtos;
using Application.Features.Payments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;



namespace Application.Features.Payments.Commands.CreatePayment;

public class CreatePaymentCommand : IRequest<CreatePaymentDto>,  ICacheRemoverRequest
{
    public int Id { get; set; }
    public int PaymentTotal { get; set; }
    public int PaymentTypeId { get; set; }
    public int CustomerId { get; set; }
    public int BeverageId { get; set; }
    public int FoodId { get; set; }
    public bool BypassCache { get; }
    public string CacheKey => "Payments-list";
    

    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, CreatePaymentDto>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        private readonly PaymentBusinessRules _paymentBusinessRules;

        public CreatePaymentCommandHandler(IPaymentRepository paymentRepository, IMapper mapper,
                                         PaymentBusinessRules paymentBusinessRules)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
            _paymentBusinessRules = paymentBusinessRules;
        }

        public async Task<CreatePaymentDto> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            await _paymentBusinessRules.PaymentIdShouldExistWhenSelected(request.CustomerId);
            Payment mappedPayment = _mapper.Map<Payment>(request);
            Payment createdPayment = await _paymentRepository.AddAsync(mappedPayment);
            CreatePaymentDto createdPaymentDto = _mapper.Map<CreatePaymentDto>(createdPayment);
            return createdPaymentDto;
        }
    }
}