using Application.Features.Payments.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Payments.Commands.DeletePayment;

public class DeletePaymentCommand : IRequest<DeletePaymentDto>, ICacheRemoverRequest
{
    public int Id { get; set; }
    public int PaymentTotal { get; set; }
    public int PaymentTypeId { get; set; }
    public int CustomerId { get; set; }
    public int BeverageId { get; set; }
    public int FoodId { get; set; }
    public bool BypassCache { get; }
    public string CacheKey => "Payments-list";
   
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, DeletePaymentDto>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public DeletePaymentCommandHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<DeletePaymentDto> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            Payment mappedPayment = _mapper.Map<Payment>(request);
            Payment deletedPayment = await _paymentRepository.DeleteAsync(mappedPayment);
            DeletePaymentDto deletedPaymentDto = _mapper.Map<DeletePaymentDto>(deletedPayment);
            return deletedPaymentDto;
        }
    }
}