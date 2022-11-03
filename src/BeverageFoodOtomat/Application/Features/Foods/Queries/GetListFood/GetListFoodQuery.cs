

using Application.Features.Foods.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Foods.Queries.GetListFood;

public class GetListFoodQuery : IRequest<FoodListModel>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; set; }
    public string CacheKey => "Foods-list";
    public TimeSpan? SlidingExpiration { get; set; }

    public class GetListFoodQueryHandler : IRequestHandler<GetListFoodQuery, FoodListModel>
    {
        private readonly IFoodRepository _FoodRepository;
        private readonly IMapper _mapper;

        public GetListFoodQueryHandler(IFoodRepository FoodRepository, IMapper mapper)
        {
            _FoodRepository = FoodRepository;
            _mapper = mapper;
        }

        public async Task<FoodListModel> Handle(GetListFoodQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Food> Foods = await _FoodRepository.GetListAsync(include:
                                                                          c => c.Include(c => c.FoodAqueousAnhydrousType)
                                                                             
                                                                              ,
                                                                          index: request.PageRequest.Page,
                                                                          size: request.PageRequest.PageSize
                                      );
            FoodListModel mappedFoodListFood = _mapper.Map<FoodListModel>(Foods);
            return mappedFoodListFood;
        }
    }
}