
using Application.Features.BeverageHotColdTypes.Dtos;
using Application.Services.Repositories;
using AutoMapper;

using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.BeverageHotColdTypes.Commands.UpdateBeverageHotColdType;

public class UpdateBeverageHotColdTypeCommand : IRequest<UpdateBeverageHotColdTypeDto>,ICacheRemoverRequest
{
  
    public bool BypassCache { get; }
    public string CacheKey => "BeverageHotColdTypes-list";
  
    public class UpdateBeverageHotColdTypeCommandHandler : IRequestHandler<UpdateBeverageHotColdTypeCommand, UpdateBeverageHotColdTypeDto>
    {
        private IBeverageHotColdTypeRepository _beverageHotColdTypeRepository { get; }
        private IMapper _mapper { get; }

        public UpdateBeverageHotColdTypeCommandHandler(IBeverageHotColdTypeRepository beverageHotColdTypeRepository, IMapper mapper)
        {
            _beverageHotColdTypeRepository = beverageHotColdTypeRepository;
            _mapper = mapper;
        }

        public async Task<UpdateBeverageHotColdTypeDto> Handle(UpdateBeverageHotColdTypeCommand request, CancellationToken cancellationToken)
        {
            BeverageHotColdType mappedBeverageHotColdType = _mapper.Map<BeverageHotColdType>(request);
            BeverageHotColdType updatedBeverageHotColdType = await _beverageHotColdTypeRepository.UpdateAsync(mappedBeverageHotColdType);
            UpdateBeverageHotColdTypeDto updatedBeverageHotColdTypeDto = _mapper.Map<UpdateBeverageHotColdTypeDto>(updatedBeverageHotColdType);
            return updatedBeverageHotColdTypeDto;
        }
    }
}