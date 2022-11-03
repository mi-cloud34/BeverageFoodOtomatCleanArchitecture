
using Application.Features.BeverageHotColdTypes.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;
namespace Application.Features.BeverageHotColdTypes.Commands.CreateBeverageHotColdType;

public class CreateBeverageHotColdTypeCommand : IRequest<CreateBeverageHotColdTypeDto>,ICacheRemoverRequest
{
   
    public bool BypassCache { get; }
    public string CacheKey => "BeverageHotColdTypes-list";
  
    public class CreateBeverageHotColdTypeCommandHandler : IRequestHandler<CreateBeverageHotColdTypeCommand, CreateBeverageHotColdTypeDto>
    {
        private readonly IBeverageHotColdTypeRepository _beverageHotColdTypeRepository;
        private readonly IMapper _mapper;
       
        public CreateBeverageHotColdTypeCommandHandler(IBeverageHotColdTypeRepository beverageHotColdTypeRepository, IMapper mapper
                                      )
        {
            _beverageHotColdTypeRepository = beverageHotColdTypeRepository;
            _mapper = mapper;
          
        }

        public async Task<CreateBeverageHotColdTypeDto> Handle(CreateBeverageHotColdTypeCommand request, CancellationToken cancellationToken)
        {
            BeverageHotColdType mappedBeverageHotColdType = _mapper.Map<BeverageHotColdType>(request);
            BeverageHotColdType createdBeverageHotColdType = await _beverageHotColdTypeRepository.AddAsync(mappedBeverageHotColdType);
            CreateBeverageHotColdTypeDto createdBeverageHotColdTypeDto = _mapper.Map<CreateBeverageHotColdTypeDto>(createdBeverageHotColdType);
            return createdBeverageHotColdTypeDto;
        }
    }
}