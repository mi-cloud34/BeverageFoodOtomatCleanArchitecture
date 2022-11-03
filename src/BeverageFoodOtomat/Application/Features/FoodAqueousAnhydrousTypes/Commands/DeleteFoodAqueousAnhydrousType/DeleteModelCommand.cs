using Application.Features.FoodAqueousAnhydrousTypes.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;


namespace Application.Features.FoodAqueousAnhydrousTypes.Commands.DeleteFoodAqueousAnhydrousType;

public class DeleteFoodAqueousAnhydrousTypeCommand : IRequest<DeleteFoodAqueousAnhydrousTypeDto>, ICacheRemoverRequest
{
    public int Id { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => "FoodAqueousAnhydrousTypes-list";
   
    public class DeleteFoodAqueousAnhydrousTypeCommandHandler : IRequestHandler<DeleteFoodAqueousAnhydrousTypeCommand, DeleteFoodAqueousAnhydrousTypeDto>
    {
        private readonly IFoodAqueousAnhydrousTypeRepository _foodAqueousAnhydrousTypeRepository;
        private readonly IMapper _mapper;

        public DeleteFoodAqueousAnhydrousTypeCommandHandler(IFoodAqueousAnhydrousTypeRepository foodAqueousAnhydrousTypeRepository, IMapper mapper)
        {
            _foodAqueousAnhydrousTypeRepository = foodAqueousAnhydrousTypeRepository;
            _mapper = mapper;
        }

        public async Task<DeleteFoodAqueousAnhydrousTypeDto> Handle(DeleteFoodAqueousAnhydrousTypeCommand request, CancellationToken cancellationToken)
        {
            FoodAqueousAnhydrousType mappedFoodAqueousAnhydrousType = _mapper.Map<FoodAqueousAnhydrousType>(request);
            FoodAqueousAnhydrousType deletedFoodAqueousAnhydrousType = await _foodAqueousAnhydrousTypeRepository.DeleteAsync(mappedFoodAqueousAnhydrousType);
            DeleteFoodAqueousAnhydrousTypeDto deletedFoodAqueousAnhydrousTypeDto = _mapper.Map<DeleteFoodAqueousAnhydrousTypeDto>(deletedFoodAqueousAnhydrousType);
            return deletedFoodAqueousAnhydrousTypeDto;
        }
    }
}