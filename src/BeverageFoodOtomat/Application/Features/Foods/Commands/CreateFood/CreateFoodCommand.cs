using Application.Features.Foods.Dtos;
using Application.Features.Foods.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;


namespace Application.Features.Foods.Commands.CreateFood;

public class CreateFoodCommand : IRequest<CreateFoodDto>, ICacheRemoverRequest
{
    public int Id { get; set; }
    public string FoodName { get; set; }
    public int FoodAqueousAnhydrousTypeId { get; set; }
    public int PlotNumber { get; set; }
    public bool BypassCache { get; }
    public string CacheKey => "Foods-list";


    public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, CreateFoodDto>
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;
        private readonly FoodBusinessRules _foodBusinessRules;


        public CreateFoodCommandHandler(IFoodRepository foodRepository, IMapper mapper,
          FoodBusinessRules foodBusinessRules                             )
        {
            _foodRepository = foodRepository;
            _mapper = mapper;
            _foodBusinessRules = foodBusinessRules;

        }

        public async Task<CreateFoodDto> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
        {
            await _foodBusinessRules.BeveragePlotCanNotBeDuplicatedWhenInserted(request.PlotNumber);
            Food mappedFood = _mapper.Map<Food>(request);
            Food createdFood = await _foodRepository.AddAsync(mappedFood);
            CreateFoodDto createdFoodDto = _mapper.Map<CreateFoodDto>(createdFood);
            return createdFoodDto;
        }
    }
}