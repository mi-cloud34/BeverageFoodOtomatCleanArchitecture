using Application.Features.BeverageSugarFreeTypes.Dtos;
using Application.Services.Repositories;
using AutoMapper;

using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;


namespace Application.Features.BeverageSugarFreeTypes.Commands.CreateBeverageSugarFreeType;

public class CreateBeverageSugarFreeTypeCommand : IRequest<CreateBeverageSugarFreeTypeDto>, ICacheRemoverRequest
{

    public bool BypassCache { get; }
    public string CacheKey => "BeverageSugarFreeTypes-list";

    public class CreateBeverageSugarFreeTypeCommandHandler : IRequestHandler<CreateBeverageSugarFreeTypeCommand, CreateBeverageSugarFreeTypeDto>
    {
        private readonly IBeverageSugarFreeTypeRepository _beverageSugarFreeTypeRepository;
        private readonly IMapper _mapper;

        public CreateBeverageSugarFreeTypeCommandHandler(IBeverageSugarFreeTypeRepository BeverageSugarFreeTypeRepository, IMapper mapper
                                        )
        {
            _beverageSugarFreeTypeRepository = BeverageSugarFreeTypeRepository;
            _mapper = mapper;

        }

        public async Task<CreateBeverageSugarFreeTypeDto> Handle(CreateBeverageSugarFreeTypeCommand request, CancellationToken cancellationToken)
        {
            BeverageSugarFreeType mappedBeverageSugarFreeType = _mapper.Map<BeverageSugarFreeType>(request);
            BeverageSugarFreeType createdBeverageSugarFreeType = await _beverageSugarFreeTypeRepository.AddAsync(mappedBeverageSugarFreeType);
            CreateBeverageSugarFreeTypeDto createdBeverageSugarFreeTypeDto = _mapper.Map<CreateBeverageSugarFreeTypeDto>(createdBeverageSugarFreeType);
            return createdBeverageSugarFreeTypeDto;
        }
    }
}