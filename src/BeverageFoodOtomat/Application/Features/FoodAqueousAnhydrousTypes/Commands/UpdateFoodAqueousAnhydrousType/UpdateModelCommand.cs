using Application.Features.FoodAqueousAnhydrousTypes.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;


namespace Application.Features.FoodAqueousAnhydrousTypes.Commands.UpdateFoodAqueousAnhydrousType;

public class UpdateFoodAqueousAnhydrousTypeCommand : IRequest<UpdateFoodAqueousAnhydrousTypeDto>, ICacheRemoverRequest
{
  
    public bool BypassCache { get; }
    public string CacheKey => "FoodAqueousAnhydrousTypes-list";
  
    public class UpdateFoodAqueousAnhydrousTypeCommandHandler : IRequestHandler<UpdateFoodAqueousAnhydrousTypeCommand, UpdateFoodAqueousAnhydrousTypeDto>
    {
        private IFoodAqueousAnhydrousTypeRepository _foodAqueousAnhydrousTypeRepository { get; }
        private IMapper _mapper { get; }

        public UpdateFoodAqueousAnhydrousTypeCommandHandler(IFoodAqueousAnhydrousTypeRepository foodAqueousAnhydrousTypeRepository, IMapper mapper)
        {
            _foodAqueousAnhydrousTypeRepository = foodAqueousAnhydrousTypeRepository;
            _mapper = mapper;
        }

        public async Task<UpdateFoodAqueousAnhydrousTypeDto> Handle(UpdateFoodAqueousAnhydrousTypeCommand request, CancellationToken cancellationToken)
        {
            FoodAqueousAnhydrousType mappedFoodAqueousAnhydrousType = _mapper.Map<FoodAqueousAnhydrousType>(request);
            FoodAqueousAnhydrousType updatedFoodAqueousAnhydrousType = await _foodAqueousAnhydrousTypeRepository.UpdateAsync(mappedFoodAqueousAnhydrousType);
            UpdateFoodAqueousAnhydrousTypeDto updatedFoodAqueousAnhydrousTypeDto = _mapper.Map<UpdateFoodAqueousAnhydrousTypeDto>(updatedFoodAqueousAnhydrousType);
            return updatedFoodAqueousAnhydrousTypeDto;
        }
    }
}