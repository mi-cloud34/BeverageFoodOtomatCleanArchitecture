
using Application.Features.FoodAqueousAnhydrousTypes.Models;
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

namespace Application.Features.FoodAqueousAnhydrousTypes.Queries.GetListFoodAqueousAnhydrousType
{
    public class GetListFoodAqueousAnhydrousTypeQuery:IRequest<FoodAqueousAnhydrousTypesListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListFoodAqueousAnhydrousTypeQueryHandler : IRequestHandler<GetListFoodAqueousAnhydrousTypeQuery, FoodAqueousAnhydrousTypesListModel>
        {
            private readonly IFoodAqueousAnhydrousTypeRepository _FoodAqueousAnhydrousTypeRepository;
            private readonly IMapper _mapper;

            public GetListFoodAqueousAnhydrousTypeQueryHandler(IFoodAqueousAnhydrousTypeRepository FoodAqueousAnhydrousTypeRepository, IMapper mapper)
            {
                _FoodAqueousAnhydrousTypeRepository = FoodAqueousAnhydrousTypeRepository;
                _mapper = mapper;
            }

            public async Task<FoodAqueousAnhydrousTypesListModel> Handle(GetListFoodAqueousAnhydrousTypeQuery request, CancellationToken cancellationToken)
            {
                IPaginate<FoodAqueousAnhydrousType> FoodAqueousAnhydrousTypes = await _FoodAqueousAnhydrousTypeRepository.GetListAsync(index: request.PageRequest.Page,size:request.PageRequest.PageSize);

                FoodAqueousAnhydrousTypesListModel mappedFoodAqueousAnhydrousTypeListModel = _mapper.Map<FoodAqueousAnhydrousTypesListModel>(FoodAqueousAnhydrousTypes);

                return mappedFoodAqueousAnhydrousTypeListModel;
            }
        }
    }
}
