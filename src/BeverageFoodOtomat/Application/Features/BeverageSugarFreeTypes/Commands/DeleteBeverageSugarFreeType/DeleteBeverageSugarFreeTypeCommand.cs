using Application.Features.BeverageSugarFreeTypes.Dtos;
using Application.Services.Repositories;
using AutoMapper;

using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.BeverageSugarFreeTypes.Commands.DeleteBeverageSugarFreeType;

public class DeleteBeverageSugarFreeTypeCommand : IRequest<DeleteBeverageSugarFreeTypeDto>, ICacheRemoverRequest
{
    public int Id { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => "BeverageSugarFreeTypes-list";

    public class DeleteBeverageSugarFreeTypeCommandHandler : IRequestHandler<DeleteBeverageSugarFreeTypeCommand, DeleteBeverageSugarFreeTypeDto>
    {
        private readonly IBeverageSugarFreeTypeRepository _beverageSugarFreeTypeRepository;
        private readonly IMapper _mapper;

        public DeleteBeverageSugarFreeTypeCommandHandler(IBeverageSugarFreeTypeRepository beverageSugarFreeTypeRepository, IMapper mapper)
        {
            _beverageSugarFreeTypeRepository = beverageSugarFreeTypeRepository;
            _mapper = mapper;
        }

        public async Task<DeleteBeverageSugarFreeTypeDto> Handle(DeleteBeverageSugarFreeTypeCommand request, CancellationToken cancellationToken)
        {
            BeverageSugarFreeType mappedBeverageSugarFreeType = _mapper.Map<BeverageSugarFreeType>(request);
            BeverageSugarFreeType deletedBeverageSugarFreeType = await _beverageSugarFreeTypeRepository.DeleteAsync(mappedBeverageSugarFreeType);
            DeleteBeverageSugarFreeTypeDto deletedBeverageSugarFreeTypeDto = _mapper.Map<DeleteBeverageSugarFreeTypeDto>(deletedBeverageSugarFreeType);
            return deletedBeverageSugarFreeTypeDto;
        }
    }
}