using Application.Features.Foods.Dtos;
using Application.Services.Repositories;
using AutoMapper;

using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;


namespace Application.Features.Foods.Commands.UpdateFood;

public class UpdateFoodCommand : IRequest<UpdateFoodDto>, ICacheRemoverRequest
{


    public bool BypassCache { get; }
    public string CacheKey => "Foods-list";


    public class UpdateFoodCommandHandler : IRequestHandler<UpdateFoodCommand, UpdateFoodDto>
    {
        private IFoodRepository _foodRepository { get; }
        private IMapper _mapper { get; }

        public UpdateFoodCommandHandler(IFoodRepository foodRepository, IMapper mapper)
        {
            _foodRepository = foodRepository;
            _mapper = mapper;
        }

        public async Task<UpdateFoodDto> Handle(UpdateFoodCommand request, CancellationToken cancellationToken)
        {
            Food mappedFood = _mapper.Map<Food>(request);
            Food updatedFood = await _foodRepository.UpdateAsync(mappedFood);
            UpdateFoodDto updatedFoodDto = _mapper.Map<UpdateFoodDto>(updatedFood);
            return updatedFoodDto;
        }
    }
}