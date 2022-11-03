using System.Threading;
using System.Threading.Tasks;
using Application.Features.Beverages.Profiles;
using Application.Features.PaymentTypes.Commands.CreatePaymentType;
using Application.Features.PaymentTypes.Commands.DeletePaymentType;
using Application.Features.PaymentTypes.Commands.UpdatePaymentType;
using Application.Features.PaymentTypes.Queries.GetByIdPaymentType;
using Application.Features.PaymentTypes.Queries.GetListPaymentType;
using Application.Features.PaymentTypes.Rules;
using Application.Services.Repositories;
using Application.Tests.Mocks.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.CrossCuttingConcerns.Exceptions;
using Moq;
using Xunit;
using static Application.Features.PaymentTypes.Commands.CreatePaymentType.CreatePaymentTypeCommand;
using static Application.Features.PaymentTypes.Commands.DeletePaymentType.DeletePaymentTypeCommand;
using static Application.Features.PaymentTypes.Commands.UpdatePaymentType.UpdatePaymentTypeCommand;
using static Application.Features.PaymentTypes.Queries.GetByIdPaymentType.GetByIdPaymentTypeQuery;
using static Application.Features.PaymentTypes.Queries.GetListPaymentType.GetListPaymentTypeQuery;
namespace Application.Tests.FeaturesTests.PaymentTypes
{
    public class PaymentTypesTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPaymentTypeRepository> _mockPaymentTypeRepository;
        private readonly PaymentTypeBusinessRules _PaymentTypeBusinessRules;

        public PaymentTypesTests()
        {
            _mockPaymentTypeRepository = new PaymentTypeMockRepository().GetRepository();

            _PaymentTypeBusinessRules = new PaymentTypeBusinessRules(_mockPaymentTypeRepository.Object);

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfiles>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task AddPaymentTypeWhenNotDuplicated()
        {
            CreatePaymentTypeCommandHandler handler = new CreatePaymentTypeCommandHandler(_mockPaymentTypeRepository.Object, _mapper, _PaymentTypeBusinessRules);
            CreatePaymentTypeCommand command = new CreatePaymentTypeCommand();
            command.PaymentTypeName = "Cash";

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.Equal("Cash", result.PaymentTypeName);

        }

        [Fact]
        public async Task AddPaymentTypeWhenDuplicated()
        {
            CreatePaymentTypeCommandHandler handler = new CreatePaymentTypeCommandHandler(_mockPaymentTypeRepository.Object, _mapper, _PaymentTypeBusinessRules);
            CreatePaymentTypeCommand command = new CreatePaymentTypeCommand();
            command.PaymentTypeName = "Cash";

            await Assert.ThrowsAsync<BusinessException>(async () => await handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task UpdatePaymentTypeWhenExistsPaymentType()
        {
            UpdatePaymentTypeCommandHandler handler = new(_mockPaymentTypeRepository.Object, _mapper);
            UpdatePaymentTypeCommand command = new UpdatePaymentTypeCommand();
            command.Id = 1;
            command.PaymentTypeName = "Cash";

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.Equal("Cash", result.PaymentTypeName);
        }

        [Fact]
        public async Task UpdatePaymentTypeWhenNotExistsPaymentType()
        {
            UpdatePaymentTypeCommandHandler handler = new(_mockPaymentTypeRepository.Object, _mapper);
            UpdatePaymentTypeCommand command = new UpdatePaymentTypeCommand();
            command.Id = 6;
            command.PaymentTypeName = "Cash";

            await Assert.ThrowsAsync<BusinessException>(async () => await handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task DeletePaymentTypeWhenExistsPaymentType()
        {
            DeletePaymentTypeCommandHandler handler = new(_mockPaymentTypeRepository.Object, _mapper);
            DeletePaymentTypeCommand command = new DeletePaymentTypeCommand();
            command.Id = 1;

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeletePaymentTypeWhenNotExistsPaymentType()
        {
            DeletePaymentTypeCommandHandler handler = new(_mockPaymentTypeRepository.Object, _mapper);
            DeletePaymentTypeCommand command = new DeletePaymentTypeCommand();
            command.Id = 6;

            await Assert.ThrowsAsync<BusinessException>(async () => await handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task GetAllPaymentTypes()
        {
            GetListPaymentTypeQueryHandler handler = new GetListPaymentTypeQueryHandler(_mockPaymentTypeRepository.Object, _mapper);
            GetListPaymentTypeQuery query = new GetListPaymentTypeQuery();
            query.PageRequest = new PageRequest
            {
                Page = 0,
                PageSize = 3
            };

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.Equal(2, result.Items.Count);
        }

        [Fact]
        public async Task GetByIdPaymentTypeWhenExistsPaymentType()
        {
            GetByIdPaymentTypeQueryHandler handler = new GetByIdPaymentTypeQueryHandler(_mockPaymentTypeRepository.Object, _mapper);
            GetByIdPaymentTypeQuery query = new GetByIdPaymentTypeQuery();
            query.Id = 1;

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.Equal("Credi", result.PaymentTypeName);
        }

        [Fact]
        public async Task GetByIdPaymentTypeWhenNotExistsPaymentType()
        {
            GetByIdPaymentTypeQueryHandler handler = new GetByIdPaymentTypeQueryHandler(_mockPaymentTypeRepository.Object, _mapper);
            GetByIdPaymentTypeQuery query = new GetByIdPaymentTypeQuery();
            query.Id = 6;

            await Assert.ThrowsAsync<BusinessException>(async () => await handler.Handle(query, CancellationToken.None));
        }
    }
}