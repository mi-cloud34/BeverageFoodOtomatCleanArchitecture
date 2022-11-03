
using Application.Features.Beverages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using MediatR;
using Domain.Entities;


namespace Application.Features.Beverages.Commands.UpdateBeverage;

public class UpdateBeverageCommand : IRequest<UpdateBeverageDto>, ICacheRemoverRequest
{

    public int Id { get; set; }
    public string BeverageName { get; set; }
    public int BeverageHotColdTypeId { get; set; }
    public int BeverageSugarFreeTypeId { get; set; }
    public int PlotNumber { get; set; }
    public bool BypassCache { get; }
    public string CacheKey => "beverage-list";
  
    public class UpdateBeverageCommandHandler : IRequestHandler<UpdateBeverageCommand, UpdateBeverageDto>
    {
        private IBeverageRepository _beverageRepository { get; }
        private IMapper _mapper { get; }

        public UpdateBeverageCommandHandler(IBeverageRepository modelRepository, IMapper mapper)
        {
            _beverageRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<UpdateBeverageDto> Handle(UpdateBeverageCommand request, CancellationToken cancellationToken)
        {
            Beverage mappedBeverage = _mapper.Map<Beverage>(request);
            Beverage updatedBeverage = await _beverageRepository.UpdateAsync(mappedBeverage);
            UpdateBeverageDto updatedBeverageDto = _mapper.Map<UpdateBeverageDto>(updatedBeverage);
            return updatedBeverageDto;
        }
    }
}