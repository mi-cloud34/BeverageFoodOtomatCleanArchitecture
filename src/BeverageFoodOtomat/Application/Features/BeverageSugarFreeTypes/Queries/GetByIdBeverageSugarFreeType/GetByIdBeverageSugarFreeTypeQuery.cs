using Application.Features.BeverageSugarFreeTypes.Dtos;

using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.BeverageSugarFreeTypes.Queries.GetByIdBeverageSugarFreeType;

public class GetByIdBeverageSugarFreeTypeQuery : IRequest<BeverageSugarFreeTypeDto>
{
    public int Id { get; set; }

    public class GetByIdBeverageSugarFreeTypeQueryHandler : IRequestHandler<GetByIdBeverageSugarFreeTypeQuery, BeverageSugarFreeTypeDto>
    {
        private readonly IBeverageSugarFreeTypeRepository _beverageSugarFreeTypeRepository;
        private readonly IMapper _mapper;
    
        public GetByIdBeverageSugarFreeTypeQueryHandler(IBeverageSugarFreeTypeRepository beverageSugarFreeTypeRepository,
                                        IMapper mapper)
        {
            _beverageSugarFreeTypeRepository = beverageSugarFreeTypeRepository;
            _mapper = mapper;
        }


        public async Task<BeverageSugarFreeTypeDto> Handle(GetByIdBeverageSugarFreeTypeQuery request, CancellationToken cancellationToken)
        {
          
            BeverageSugarFreeType? BeverageSugarFreeType = await _beverageSugarFreeTypeRepository.GetAsync(b => b.Id == request.Id);
            BeverageSugarFreeTypeDto BeverageSugarFreeTypeDto = _mapper.Map<BeverageSugarFreeTypeDto>(BeverageSugarFreeType);
            return BeverageSugarFreeTypeDto;
        }
    }
}