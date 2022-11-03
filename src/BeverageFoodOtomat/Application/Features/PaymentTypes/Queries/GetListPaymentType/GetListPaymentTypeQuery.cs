
using Application.Features.PaymentTypes.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PaymentTypes.Queries.GetListPaymentType
{
    public class GetListPaymentTypeQuery:IRequest<PaymentTypeListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListPaymentTypeQueryHandler : IRequestHandler<GetListPaymentTypeQuery, PaymentTypeListModel>
        {
            private readonly IPaymentTypeRepository _paymentTypeRepository;
            private readonly IMapper _mapper;

            public GetListPaymentTypeQueryHandler(IPaymentTypeRepository paymentTypeRepository, IMapper mapper)
            {
                _paymentTypeRepository = paymentTypeRepository;
                _mapper = mapper;
            }

            public async Task<PaymentTypeListModel> Handle(GetListPaymentTypeQuery request, CancellationToken cancellationToken)
            {
                IPaginate<PaymentType> PaymentTypes = await _paymentTypeRepository.GetListAsync(index: request.PageRequest.Page,size:request.PageRequest.PageSize);

                PaymentTypeListModel mappedPaymentTypeListModel = _mapper.Map<PaymentTypeListModel>(PaymentTypes);

                return mappedPaymentTypeListModel;
            }
        }
    }
}
