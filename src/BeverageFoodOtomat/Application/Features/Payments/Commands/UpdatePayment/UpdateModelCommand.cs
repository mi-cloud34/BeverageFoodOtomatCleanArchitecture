
using Application.Features.Payments.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;


namespace Application.Features.Payments.Commands.UpdatePayment;

public class UpdatePaymentCommand : IRequest<UpdatePaymentDto>,  ICacheRemoverRequest
{
    public int Id { get; set; }
    public int PaymentTotal { get; set; }
    public int PaymentTypeId { get; set; }
    public int CustomerId { get; set; }
    public int BeverageId { get; set; }
    public int FoodId { get; set; }
    public bool BypassCache { get; }
    public string CacheKey => "Payments-list";
  
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, UpdatePaymentDto>
    {
        private IPaymentRepository _paymentRepository { get; }
        private IMapper _mapper { get; }

        public UpdatePaymentCommandHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<UpdatePaymentDto> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            Payment mappedPayment = _mapper.Map<Payment>(request);
            Payment updatedPayment = await _paymentRepository.UpdateAsync(mappedPayment);
            UpdatePaymentDto updatedPaymentDto = _mapper.Map<UpdatePaymentDto>(updatedPayment);
            return updatedPaymentDto;
        }
    }
}