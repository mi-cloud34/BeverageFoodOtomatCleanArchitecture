
using Application.Features.BeverageHotColdTypes.Models;
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

namespace Application.Features.BeverageHotColdTypes.Queries.GetListBeverageHotColdType
{
    public class GetListBeverageHotColdTypeQuery:IRequest<BeverageHotColdTypeListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListBeverageHotColdTypeQueryHandler : IRequestHandler<GetListBeverageHotColdTypeQuery, BeverageHotColdTypeListModel>
        {
            private readonly IBeverageHotColdTypeRepository _BeverageHotColdTypeRepository;
            private readonly IMapper _mapper;

            public GetListBeverageHotColdTypeQueryHandler(IBeverageHotColdTypeRepository BeverageHotColdTypeRepository, IMapper mapper)
            {
                _BeverageHotColdTypeRepository = BeverageHotColdTypeRepository;
                _mapper = mapper;
            }

            public async Task<BeverageHotColdTypeListModel> Handle(GetListBeverageHotColdTypeQuery request, CancellationToken cancellationToken)
            {
                IPaginate<BeverageHotColdType> BeverageHotColdTypes = await _BeverageHotColdTypeRepository.GetListAsync(index: request.PageRequest.Page,size:request.PageRequest.PageSize);

                BeverageHotColdTypeListModel mappedBeverageHotColdTypeListModel = _mapper.Map<BeverageHotColdTypeListModel>(BeverageHotColdTypes);

                return mappedBeverageHotColdTypeListModel;
            }
        }
    }
}
