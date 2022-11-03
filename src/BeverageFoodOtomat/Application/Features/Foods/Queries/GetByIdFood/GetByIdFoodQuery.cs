
using Application.Features.Foods.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Foods.Queries.GetByIdFood;

public class GetByIdFoodQuery : IRequest<FoodDto>
{
    public int Id { get; set; }

    public class GetByIdFoodQueryHandler : IRequestHandler<GetByIdFoodQuery, FoodDto>
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;
      
        public GetByIdFoodQueryHandler(IFoodRepository foodRepository,
                                        IMapper mapper)
        {
            _foodRepository = foodRepository;
          
            _mapper = mapper;
        }


        public async Task<FoodDto> Handle(GetByIdFoodQuery request, CancellationToken cancellationToken)
        {
           
            Food? Food = await _foodRepository.GetAsync(m => m.Id == request.Id);
            FoodDto FoodDto = _mapper.Map<FoodDto>(Food);
            return FoodDto;
        }
    }
}