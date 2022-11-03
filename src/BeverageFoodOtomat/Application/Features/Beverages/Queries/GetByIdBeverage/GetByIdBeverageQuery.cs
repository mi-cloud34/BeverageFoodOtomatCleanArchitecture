
using Application.Features.Beverages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Beverages.Queries.GetByIdBeverage;

public class GetByIdBeverageQuery : IRequest<BeverageDto>
{
    public int Id { get; set; }

    public class GetByIdBeverageQueryHandler : IRequestHandler<GetByIdBeverageQuery, BeverageDto>
    {
        private readonly IBeverageRepository _beverageRepository;
        private readonly IMapper _mapper;
      
        public GetByIdBeverageQueryHandler(IBeverageRepository beverageRepository,
                                        IMapper mapper)
        {
            _beverageRepository = beverageRepository;
          
            _mapper = mapper;
        }


        public async Task<BeverageDto> Handle(GetByIdBeverageQuery request, CancellationToken cancellationToken)
        {
           
            Beverage? Beverage = await _beverageRepository.GetAsync(m => m.Id == request.Id);
            BeverageDto BeverageDto = _mapper.Map<BeverageDto>(Beverage);
            return BeverageDto;
        }
    }
}