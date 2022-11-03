using Application.Features.PaymentTypes.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.PaymentTypes.Commands.DeletePaymentType;

public class DeletePaymentTypeCommand : IRequest<DeletePaymentTypeDto>, ICacheRemoverRequest
{
    public int Id { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => "PaymentTypes-list";

    public class DeletePaymentTypeCommandHandler : IRequestHandler<DeletePaymentTypeCommand, DeletePaymentTypeDto>
    {
        private readonly IPaymentTypeRepository _paymentTypeRepository;
        private readonly IMapper _mapper;

        public DeletePaymentTypeCommandHandler(IPaymentTypeRepository paymentTypeRepository, IMapper mapper)
        {
            _paymentTypeRepository = paymentTypeRepository;
            _mapper = mapper;
        }

        public async Task<DeletePaymentTypeDto> Handle(DeletePaymentTypeCommand request, CancellationToken cancellationToken)
        {
            PaymentType mappedPaymentType = _mapper.Map<PaymentType>(request);
            PaymentType deletedPaymentType = await _paymentTypeRepository.DeleteAsync(mappedPaymentType);
            DeletePaymentTypeDto deletedPaymentTypeDto = _mapper.Map<DeletePaymentTypeDto>(deletedPaymentType);
            return deletedPaymentTypeDto;
        }
    }
}