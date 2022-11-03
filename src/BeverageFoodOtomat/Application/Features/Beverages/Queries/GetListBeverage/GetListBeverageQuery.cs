
using Application.Features.Beverages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Beverages.Queries.GetListBeverage;

public class GetListBeverageQuery : IRequest<BeverageListModel>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; set; }
    public string CacheKey => "Beverages-list";
    public TimeSpan? SlidingExpiration { get; set; }

    public class GetListBeverageQueryHandler : IRequestHandler<GetListBeverageQuery, BeverageListModel>
    {
        private readonly IBeverageRepository _beverageRepository;
        private readonly IMapper _mapper;

        public GetListBeverageQueryHandler(IBeverageRepository beverageRepository, IMapper mapper)
        {
            _beverageRepository = beverageRepository;
            _mapper = mapper;
        }

        public async Task<BeverageListModel> Handle(GetListBeverageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Beverage> Beverages = await _beverageRepository.GetListAsync(include:
                                                                          c => c.Include(c => c.BeverageHotColdType)
                                                                              .Include(c => c.BeverageSugarFreeType)
                                                                              ,
                                                                          index: request.PageRequest.Page,
                                                                          size: request.PageRequest.PageSize
                                      );
            BeverageListModel mappedBeverageListBeverage = _mapper.Map<BeverageListModel>(Beverages);
            return mappedBeverageListBeverage;
        }
    }
}