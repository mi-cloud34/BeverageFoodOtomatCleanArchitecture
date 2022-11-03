using System.Threading;
using System.Threading.Tasks;
using Application.Features.Beverages.Profiles;
using Application.Features.Beverages.Commands.CreateBeverage;
using Application.Features.Beverages.Commands.DeleteBeverage;
using Application.Features.Beverages.Commands.UpdateBeverage;
using Application.Features.Beverages.Queries.GetByIdBeverage;
using Application.Features.Beverages.Queries.GetListBeverage;
using Application.Features.Beverages.Rules;
using Application.Services.Repositories;
using Application.Tests.Mocks.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.CrossCuttingConcerns.Exceptions;
using Moq;
using Xunit;
using static Application.Features.Beverages.Commands.CreateBeverage.CreateBeverageCommand;
using static Application.Features.Beverages.Commands.DeleteBeverage.DeleteBeverageCommand;
using static Application.Features.Beverages.Commands.UpdateBeverage.UpdateBeverageCommand;
using static Application.Features.Beverages.Queries.GetByIdBeverage.GetByIdBeverageQuery;
using static Application.Features.Beverages.Queries.GetListBeverage.GetListBeverageQuery;
namespace Application.Tests.FeaturesTests.Beverages
{
    public class BeveragesTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBeverageRepository> _mockBeverageRepository;
        private readonly BeverageBusinessRules _BeverageBusinessRules;

        public BeveragesTests()
        {
            _mockBeverageRepository = new BeverageMockRepository().GetRepository();

            _BeverageBusinessRules = new BeverageBusinessRules(_mockBeverageRepository.Object);

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfiles>();
            });

            _mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task AddBeverageWhenDuplicated()
        {
            CreateBeverageCommandHandler handler = new(_mockBeverageRepository.Object, _mapper, _BeverageBusinessRules);
            CreateBeverageCommand command = new();
            command.BeverageName = "Cola";

            await Assert.ThrowsAsync<BusinessException>(async () => await handler.Handle(command, CancellationToken.None));
        }
        [Fact]
        public async Task AddBeverageWhenNotDuplicated()
        {
            CreateBeverageCommandHandler handler = new(_mockBeverageRepository.Object, _mapper, _BeverageBusinessRules);
            CreateBeverageCommand command = new();
            command.BeverageName = "Cola";

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.Equal("Cola", result.BeverageName);

        }

        [Fact]
        public async Task UpdateBeverageWhenExistsBeverage()
        {
            UpdateBeverageCommandHandler handler = new(_mockBeverageRepository.Object, _mapper);
            UpdateBeverageCommand command = new();
            command.Id = 1;
            command.BeverageName = "Cola";

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.Equal("Cola", result.BeverageName);
        }

        [Fact]
        public async Task UpdateBeverageWhenNotExistsBeverage()
        {
            UpdateBeverageCommandHandler handler = new(_mockBeverageRepository.Object, _mapper);
            UpdateBeverageCommand command = new();
            command.Id = 6;
            command.BeverageName = "Cola";

            await Assert.ThrowsAsync<BusinessException>(async () => await handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task DeleteBeverageWhenExistsBeverage()
        {
            DeleteBeverageCommandHandler handler = new(_mockBeverageRepository.Object, _mapper);
            DeleteBeverageCommand command = new();
            command.Id = 1;

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeleteBeverageWhenNotExistsBeverage()
        {
            DeleteBeverageCommandHandler handler = new(_mockBeverageRepository.Object, _mapper);
            DeleteBeverageCommand command = new();
            command.Id = 6;

            await Assert.ThrowsAsync<BusinessException>(async () => await handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task GetAllBeverages()
        {
            GetListBeverageQueryHandler handler = new(_mockBeverageRepository.Object, _mapper);
            GetListBeverageQuery query = new();
            query.PageRequest = new PageRequest
            {
                Page = 0,
                PageSize = 3
            };

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.Equal(2, result.Items.Count);
        }

        [Fact]
        public async Task GetByIdBeverageWhenExistsBeverage()
        {
            GetByIdBeverageQueryHandler handler = new(_mockBeverageRepository.Object, _mapper);
            GetByIdBeverageQuery query = new();
            query.Id = 1;

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.Equal("Cola", result.BeverageName);
        }

        [Fact]
        public async Task GetByIdBeverageWhenNotExistsBeverage()
        {
            GetByIdBeverageQueryHandler handler = new(_mockBeverageRepository.Object, _mapper);
            GetByIdBeverageQuery query = new();
            query.Id = 6;

            await Assert.ThrowsAsync<BusinessException>(async () => await handler.Handle(query, CancellationToken.None));
        }
    }
}