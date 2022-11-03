using Application.Features.FoodAqueousAnhydrousTypes.Dtos;
using Application.Features.FoodAqueousAnhydrousTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;

using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;


namespace Application.Features.FoodAqueousAnhydrousTypes.Commands.CreateFoodAqueousAnhydrousType;

public class CreateFoodAqueousAnhydrousTypeCommand : IRequest<CreateFoodAqueousAnhydrousTypeDto>, ICacheRemoverRequest
{
 

    public bool BypassCache { get; }
    public string CacheKey => "FoodAqueousAnhydrousTypes-list";
   
    public class CreateFoodAqueousAnhydrousTypeCommandHandler : IRequestHandler<CreateFoodAqueousAnhydrousTypeCommand, CreateFoodAqueousAnhydrousTypeDto>
    {
        private readonly IFoodAqueousAnhydrousTypeRepository _foodAqueousAnhydrousTypeRepository;
        private readonly IMapper _mapper;
        private readonly FoodAqueousAnhydrousTypeBusinessRules _foodAqueousAnhydrousTypeBusinessRules;

        public CreateFoodAqueousAnhydrousTypeCommandHandler(IFoodAqueousAnhydrousTypeRepository foodAqueousAnhydrousTypeRepository, IMapper mapper,
                                         FoodAqueousAnhydrousTypeBusinessRules foodAqueousAnhydrousTypeBusinessRules)
        {
            _foodAqueousAnhydrousTypeRepository = foodAqueousAnhydrousTypeRepository;
            _mapper = mapper;
            _foodAqueousAnhydrousTypeBusinessRules = foodAqueousAnhydrousTypeBusinessRules;
        }

        public async Task<CreateFoodAqueousAnhydrousTypeDto> Handle(CreateFoodAqueousAnhydrousTypeCommand request, CancellationToken cancellationToken)
        {
            FoodAqueousAnhydrousType mappedFoodAqueousAnhydrousType = _mapper.Map<FoodAqueousAnhydrousType>(request);
            FoodAqueousAnhydrousType createdFoodAqueousAnhydrousType = await _foodAqueousAnhydrousTypeRepository.AddAsync(mappedFoodAqueousAnhydrousType);
            CreateFoodAqueousAnhydrousTypeDto createdFoodAqueousAnhydrousTypeDto = _mapper.Map<CreateFoodAqueousAnhydrousTypeDto>(createdFoodAqueousAnhydrousType);
            return createdFoodAqueousAnhydrousTypeDto;
        }
    }
}