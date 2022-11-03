using Application.Features.BeverageSugarFreeTypes.Models;
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

namespace Application.Features.BeverageSugarFreeTypes.Queries.GetListBeverageSugarFreeType
{
    public class GetListBeverageSugarFreeTypeQuery:IRequest<BeverageSugarFreeTypeListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListBeverageSugarFreeTypeQueryHandler : IRequestHandler<GetListBeverageSugarFreeTypeQuery, BeverageSugarFreeTypeListModel>
        {
            private readonly IBeverageSugarFreeTypeRepository _BeverageSugarFreeTypeRepository;
            private readonly IMapper _mapper;

            public GetListBeverageSugarFreeTypeQueryHandler(IBeverageSugarFreeTypeRepository BeverageSugarFreeTypeRepository, IMapper mapper)
            {
                _BeverageSugarFreeTypeRepository = BeverageSugarFreeTypeRepository;
                _mapper = mapper;
            }

            public async Task<BeverageSugarFreeTypeListModel> Handle(GetListBeverageSugarFreeTypeQuery request, CancellationToken cancellationToken)
            {
                IPaginate<BeverageSugarFreeType> BeverageSugarFreeTypes = await _BeverageSugarFreeTypeRepository.GetListAsync(index: request.PageRequest.Page,size:request.PageRequest.PageSize);

                BeverageSugarFreeTypeListModel mappedBeverageSugarFreeTypeListModel = _mapper.Map<BeverageSugarFreeTypeListModel>(BeverageSugarFreeTypes);

                return mappedBeverageSugarFreeTypeListModel;
            }
        }
    }
}
