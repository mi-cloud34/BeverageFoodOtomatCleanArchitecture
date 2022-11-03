using System.Threading;
using System.Threading.Tasks;
using Application.Features.Beverages.Profiles;
using Application.Features.Payments.Commands.CreatePayment;
using Application.Features.Payments.Commands.DeletePayment;
using Application.Features.Payments.Commands.UpdatePayment;
using Application.Features.Payments.Queries.GetByIdPayment;
using Application.Features.Payments.Queries.GetListPayment;
using Application.Features.Payments.Rules;
using Application.Services.Repositories;
using Application.Tests.Mocks.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.CrossCuttingConcerns.Exceptions;
using Moq;
using Xunit;
using static Application.Features.Payments.Commands.CreatePayment.CreatePaymentCommand;
using static Application.Features.Payments.Commands.DeletePayment.DeletePaymentCommand;
using static Application.Features.Payments.Commands.UpdatePayment.UpdatePaymentCommand;
using static Application.Features.Payments.Queries.GetByIdPayment.GetByIdPaymentQuery;
using static Application.Features.Payments.Queries.GetListPayment.GetListPaymentQuery;
namespace Application.Tests.FeaturesTests.Payments
{
    public class PaymentsTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPaymentRepository> _mockPaymentRepository;
        private readonly PaymentBusinessRules _PaymentBusinessRules;

        public PaymentsTests()
        {
            _mockPaymentRepository = new PaymentMockRepository().GetRepository();

            _PaymentBusinessRules = new PaymentBusinessRules(_mockPaymentRepository.Object);

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfiles>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task AddPaymentWhenNotDuplicated()
        {
            CreatePaymentCommandHandler handler = new CreatePaymentCommandHandler(_mockPaymentRepository.Object, _mapper, _PaymentBusinessRules);
            CreatePaymentCommand command = new CreatePaymentCommand();
            command.PaymentTotal =35;

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.Equal(35, result.PaymentTotal);

        }

        [Fact]
        public async Task AddPaymentWhenDuplicated()
        {
            CreatePaymentCommandHandler handler = new CreatePaymentCommandHandler(_mockPaymentRepository.Object, _mapper, _PaymentBusinessRules);
            CreatePaymentCommand command = new CreatePaymentCommand();
            command.PaymentTotal = 80;

            await Assert.ThrowsAsync<BusinessException>(async () => await handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task UpdatePaymentWhenExistsPayment()
        {
            UpdatePaymentCommandHandler handler = new(_mockPaymentRepository.Object, _mapper);
            UpdatePaymentCommand command = new UpdatePaymentCommand();
            command.Id = 1;
            command.CustomerId = 3;

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.Equal(2, result.CustomerId);
        }

        [Fact]
        public async Task UpdatePaymentWhenNotExistsPayment()
        {
            UpdatePaymentCommandHandler handler = new(_mockPaymentRepository.Object, _mapper);
            UpdatePaymentCommand command = new UpdatePaymentCommand();
            command.Id = 6;
            command.PaymentTotal = 100;

            await Assert.ThrowsAsync<BusinessException>(async () => await handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task DeletePaymentWhenExistsPayment()
        {
            DeletePaymentCommandHandler handler = new(_mockPaymentRepository.Object, _mapper);
            DeletePaymentCommand command = new DeletePaymentCommand();
            command.Id = 1;

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeletePaymentWhenNotExistsPayment()
        {
            DeletePaymentCommandHandler handler = new(_mockPaymentRepository.Object, _mapper);
            DeletePaymentCommand command = new DeletePaymentCommand();
            command.Id = 6;

            await Assert.ThrowsAsync<BusinessException>(async () => await handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task GetAllPayments()
        {
            GetListPaymentQueryHandler handler = new GetListPaymentQueryHandler(_mockPaymentRepository.Object, _mapper);
            GetListPaymentQuery query = new GetListPaymentQuery();
            query.PageRequest = new PageRequest
            {
                Page = 0,
                PageSize = 3
            };

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.Equal(2, result.Items.Count);
        }

        [Fact]
        public async Task GetByIdPaymentWhenExistsPayment()
        {
            GetByIdPaymentQueryHandler handler = new GetByIdPaymentQueryHandler(_mockPaymentRepository.Object, _mapper);
            GetByIdPaymentQuery query = new GetByIdPaymentQuery();
            query.Id = 1;

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.Equal(80, result.PaymentTotal);
        }

        [Fact]
        public async Task GetByIdPaymentWhenNotExistsPayment()
        {
            GetByIdPaymentQueryHandler handler = new GetByIdPaymentQueryHandler(_mockPaymentRepository.Object, _mapper);
            GetByIdPaymentQuery query = new GetByIdPaymentQuery();
            query.Id = 6;

            await Assert.ThrowsAsync<BusinessException>(async () => await handler.Handle(query, CancellationToken.None));
        }
    }
}