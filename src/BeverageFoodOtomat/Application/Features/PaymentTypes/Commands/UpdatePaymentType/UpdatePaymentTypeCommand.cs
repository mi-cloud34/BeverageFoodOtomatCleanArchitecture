using Application.Features.PaymentTypes.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;


namespace Application.Features.PaymentTypes.Commands.UpdatePaymentType;

public class UpdatePaymentTypeCommand : IRequest<UpdatePaymentTypeDto>, ICacheRemoverRequest
{

    public int Id { get; set; }
    public string PaymentTypeName { get; set; }
    public bool BypassCache { get; }
    public string CacheKey => "PaymentTypes-list";

    public class UpdatePaymentTypeCommandHandler : IRequestHandler<UpdatePaymentTypeCommand, UpdatePaymentTypeDto>
    {
        private IPaymentTypeRepository _paymentTypeRepository { get; }
        private IMapper _mapper { get; }

        public UpdatePaymentTypeCommandHandler(IPaymentTypeRepository paymentTypeRepository, IMapper mapper)
        {
            _paymentTypeRepository = paymentTypeRepository;
            _mapper = mapper;
        }

        public async Task<UpdatePaymentTypeDto> Handle(UpdatePaymentTypeCommand request, CancellationToken cancellationToken)
        {
            PaymentType mappedPaymentType = _mapper.Map<PaymentType>(request);
            PaymentType updatedPaymentType = await _paymentTypeRepository.UpdateAsync(mappedPaymentType);
            UpdatePaymentTypeDto updatedPaymentTypeDto = _mapper.Map<UpdatePaymentTypeDto>(updatedPaymentType);
            return updatedPaymentTypeDto;
        }
    }
}