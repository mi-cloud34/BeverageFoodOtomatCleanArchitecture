using Application.Features.Foods.Dtos;
using Application.Services.Repositories;
using AutoMapper;

using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;


namespace Application.Features.Foods.Commands.DeleteFood;

public class DeleteFoodCommand : IRequest<DeleteFoodDto>, ICacheRemoverRequest
{
    public int Id { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => "Foods-list";


    public class DeleteFoodCommandHandler : IRequestHandler<DeleteFoodCommand, DeleteFoodDto>
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;

        public DeleteFoodCommandHandler(IFoodRepository foodRepository, IMapper mapper)
        {
            _foodRepository = foodRepository;
            _mapper = mapper;
        }

        public async Task<DeleteFoodDto> Handle(DeleteFoodCommand request, CancellationToken cancellationToken)
        {
            Food mappedFood = _mapper.Map<Food>(request);
            Food deletedFood = await _foodRepository.DeleteAsync(mappedFood);
            DeleteFoodDto deletedFoodDto = _mapper.Map<DeleteFoodDto>(deletedFood);
            return deletedFoodDto;
        }
    }
}