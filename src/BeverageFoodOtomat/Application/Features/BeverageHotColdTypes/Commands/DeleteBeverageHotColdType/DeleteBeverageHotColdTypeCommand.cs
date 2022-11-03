
using Application.Features.BeverageHotColdTypes.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.BeverageHotColdTypes.Commands.DeleteBeverageHotColdType;

public class DeleteBeverageHotColdTypeCommand : IRequest<DeleteBeverageHotColdTypeDto>,ICacheRemoverRequest
{
    public int Id { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => "BeverageHotColdTypes-list";
  
    public class DeleteBeverageHotColdTypeCommandHandler : IRequestHandler<DeleteBeverageHotColdTypeCommand, DeleteBeverageHotColdTypeDto>
    {
        private readonly IBeverageHotColdTypeRepository _beverageHotColdTypeRepository;
        private readonly IMapper _mapper;

        public DeleteBeverageHotColdTypeCommandHandler(IBeverageHotColdTypeRepository beverageHotColdTypeRepository, IMapper mapper)
        {
            _beverageHotColdTypeRepository = beverageHotColdTypeRepository;
            _mapper = mapper;
        }

        public async Task<DeleteBeverageHotColdTypeDto> Handle(DeleteBeverageHotColdTypeCommand request, CancellationToken cancellationToken)
        {
            BeverageHotColdType mappedBeverageHotColdType = _mapper.Map<BeverageHotColdType>(request);
            BeverageHotColdType deletedBeverageHotColdType = await _beverageHotColdTypeRepository.DeleteAsync(mappedBeverageHotColdType);
            DeleteBeverageHotColdTypeDto deletedBeverageHotColdTypeDto = _mapper.Map<DeleteBeverageHotColdTypeDto>(deletedBeverageHotColdType);
            return deletedBeverageHotColdTypeDto;
        }
    }
}