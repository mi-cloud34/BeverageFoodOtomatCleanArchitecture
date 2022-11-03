using Application.Features.BeverageSugarFreeTypes.Dtos;
using Application.Services.Repositories;
using AutoMapper;

using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.BeverageSugarFreeTypes.Commands.UpdateBeverageSugarFreeType;

public class UpdateBeverageSugarFreeTypeCommand : IRequest<UpdateBeverageSugarFreeTypeDto>, ICacheRemoverRequest
{

    public bool BypassCache { get; }
    public string CacheKey => "BeverageSugarFreeTypes-list";

    public class UpdateBeverageSugarFreeTypeCommandHandler : IRequestHandler<UpdateBeverageSugarFreeTypeCommand, UpdateBeverageSugarFreeTypeDto>
    {
        private IBeverageSugarFreeTypeRepository _beverageSugarFreeTypeRepository { get; }
        private IMapper _mapper { get; }

        public UpdateBeverageSugarFreeTypeCommandHandler(IBeverageSugarFreeTypeRepository beverageSugarFreeTypeRepository, IMapper mapper)
        {
            _beverageSugarFreeTypeRepository = beverageSugarFreeTypeRepository;
            _mapper = mapper;
        }

        public async Task<UpdateBeverageSugarFreeTypeDto> Handle(UpdateBeverageSugarFreeTypeCommand request, CancellationToken cancellationToken)
        {
            BeverageSugarFreeType mappedBeverageSugarFreeType = _mapper.Map<BeverageSugarFreeType>(request);
            BeverageSugarFreeType updatedBeverageSugarFreeType = await _beverageSugarFreeTypeRepository.UpdateAsync(mappedBeverageSugarFreeType);
            UpdateBeverageSugarFreeTypeDto updatedBeverageSugarFreeTypeDto = _mapper.Map<UpdateBeverageSugarFreeTypeDto>(updatedBeverageSugarFreeType);
            return updatedBeverageSugarFreeTypeDto;
        }
    }
}