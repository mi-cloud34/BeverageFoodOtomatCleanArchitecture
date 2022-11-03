using Application.Features.FoodAqueousAnhydrousTypes.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.FoodAqueousAnhydrousTypes.Queries.GetByIdFoodAqueousAnhydrousType;

public class GetByIdFoodAqueousAnhydrousTypesQuery : IRequest<FoodAqueousAnhydrousTypeDto>
{
    public int Id { get; set; }

    public class GetByIdFoodAqueousAnhydrousTypesQueryHandler : IRequestHandler<GetByIdFoodAqueousAnhydrousTypesQuery, FoodAqueousAnhydrousTypeDto>
    {
        private readonly IFoodAqueousAnhydrousTypeRepository _foodAqueousAnhydrousTypesRepository;
        private readonly IMapper _mapper;

        public GetByIdFoodAqueousAnhydrousTypesQueryHandler(IFoodAqueousAnhydrousTypeRepository foodAqueousAnhydrousTypeRepository,
                                        IMapper mapper)
        {
            _foodAqueousAnhydrousTypesRepository = foodAqueousAnhydrousTypeRepository;
            _mapper = mapper;
        }


        public async Task<FoodAqueousAnhydrousTypeDto> Handle(GetByIdFoodAqueousAnhydrousTypesQuery request, CancellationToken cancellationToken)
        {
            FoodAqueousAnhydrousType? FoodAqueousAnhydrousTypes = await _foodAqueousAnhydrousTypesRepository.GetAsync(b => b.Id == request.Id);
            FoodAqueousAnhydrousTypeDto FoodAqueousAnhydrousTypesDto = _mapper.Map<FoodAqueousAnhydrousTypeDto>(FoodAqueousAnhydrousTypes);
            return FoodAqueousAnhydrousTypesDto;
        }
    }
}