using Application.Features.Beverages.Dtos;
using Application.Features.Beverages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;


namespace Application.Features.Beverages.Commands.CreateBeverage;

public class CreateBeverageCommand : IRequest<CreateBeverageDto>, ICacheRemoverRequest
{
    public int Id { get; set; }
    public string BeverageName { get; set; }
    public int BeverageHotColdTypeId { get; set; }
    public int BeverageSugarFreeTypeId { get; set; }
    public int PlotNumber { get; set; }
    public bool BypassCache { get; }
    public string CacheKey => "BeverageSugarFreeTypes-list";

    public class CreateBeverageCommandHandler : IRequestHandler<CreateBeverageCommand, CreateBeverageDto>
    {
        private readonly IBeverageRepository _beverageRepository;
        private readonly IMapper _mapper;
        private readonly BeverageBusinessRules _beverageBusinessRules;
        public CreateBeverageCommandHandler(IBeverageRepository beverageRepository, IMapper mapper,
                      BeverageBusinessRules   beverageBusinessRules               )
        {
            _beverageRepository = beverageRepository;
            _mapper = mapper;
            _beverageBusinessRules = beverageBusinessRules;

        }

        public async Task<CreateBeverageDto> Handle(CreateBeverageCommand request, CancellationToken cancellationToken)
        {
            await _beverageBusinessRules.BeveragePlotCanNotBeDuplicatedWhenInserted(request.PlotNumber);
            Beverage mappedBeverage = _mapper.Map<Beverage>(request);
            Beverage createdBeverageType = await _beverageRepository.AddAsync(mappedBeverage);
            CreateBeverageDto createdBeverageDto = _mapper.Map<CreateBeverageDto>(createdBeverageType);
            return createdBeverageDto;
        }
    }
}