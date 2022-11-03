using Application.Features.BeverageHotColdTypes.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.BeverageHotColdTypes.Queries.GetByIdBeverageHotColdType;

public class GetByIdBeverageHotColdTypeQuery : IRequest<BeverageHotColdTypeDto>
{
    public int Id { get; set; }

    public class GetByIdBeverageHotColdTypeQueryHandler : IRequestHandler<GetByIdBeverageHotColdTypeQuery, BeverageHotColdTypeDto>
    {
        private readonly IBeverageHotColdTypeRepository _beverageHotColdTypeRepository;
        private readonly IMapper _mapper;
     
        public GetByIdBeverageHotColdTypeQueryHandler(IBeverageHotColdTypeRepository BeverageHotColdTypeRepository,
                                        IMapper mapper)
        {
            _beverageHotColdTypeRepository = BeverageHotColdTypeRepository;
           
            _mapper = mapper;
        }


        public async Task<BeverageHotColdTypeDto> Handle(GetByIdBeverageHotColdTypeQuery request, CancellationToken cancellationToken)
        {
          
            BeverageHotColdType? BeverageHotColdType = await _beverageHotColdTypeRepository.GetAsync(b => b.Id == request.Id);
            BeverageHotColdTypeDto BeverageHotColdTypeDto = _mapper.Map<BeverageHotColdTypeDto>(BeverageHotColdType);
            return BeverageHotColdTypeDto;
        }
    }
}