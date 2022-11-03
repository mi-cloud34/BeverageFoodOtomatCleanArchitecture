using Application.Features.Beverages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Beverages.Commands.DeleteBeverage
{
    public class DeleteBeverageCommand : IRequest<DeleteBeverageDto>, ICacheRemoverRequest
    {
        public int Id { get; set; }

        public bool BypassCache { get; }
        public string CacheKey => "beverage-list";


        public class DeleteBeverageCommandHandler : IRequestHandler<DeleteBeverageCommand, DeleteBeverageDto>
        {
            private readonly IBeverageRepository _beverageRepository;
            private readonly IMapper _mapper;

            public DeleteBeverageCommandHandler(IBeverageRepository modelRepository, IMapper mapper)
            {
                _beverageRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<DeleteBeverageDto> Handle(DeleteBeverageCommand request, CancellationToken cancellationToken)
            {
                Beverage mappedBeverage = _mapper.Map<Beverage>(request);
                Beverage deletedBeverage = await _beverageRepository.DeleteAsync(mappedBeverage);
                DeleteBeverageDto deletedBeverageDto = _mapper.Map<DeleteBeverageDto>(deletedBeverage);
                return deletedBeverageDto;
            }
        }
    }
}
