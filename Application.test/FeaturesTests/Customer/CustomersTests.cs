using System.Threading;
using System.Threading.Tasks;
using Application.Features.Beverages.Profiles;
using Application.Features.Customers.Commands.CreateCustomer;
using Application.Features.Customers.Commands.DeleteCustomer;
using Application.Features.Customers.Commands.UpdateCustomer;
using Application.Features.Customers.Queries.GetByIdCustomer;
using Application.Features.Customers.Queries.GetListCustomer;
using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using Application.Tests.Mocks.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.CrossCuttingConcerns.Exceptions;
using Moq;
using Xunit;
using static Application.Features.Customers.Commands.CreateCustomer.CreateCustomerCommand;
using static Application.Features.Customers.Commands.DeleteCustomer.DeleteCustomerCommand;
using static Application.Features.Customers.Commands.UpdateCustomer.UpdateCustomerCommand;
using static Application.Features.Customers.Queries.GetByIdCustomer.GetByIdCustomerQuery;
using static Application.Features.Customers.Queries.GetListCustomer.GetListCustomerQuery;
namespace Application.Tests.FeaturesTests.Customers
{
    public class CustomersTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;
        private readonly CustomerBusinessRules _CustomerBusinessRules;

        public CustomersTests()
        {
            _mockCustomerRepository = new CustomerMockRepository().GetRepository();

            _CustomerBusinessRules = new CustomerBusinessRules(_mockCustomerRepository.Object);

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfiles>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task AddCustomerWhenNotDuplicated()
        {
            CreateCustomerCommandHandler handler = new(_mockCustomerRepository.Object, _mapper, _CustomerBusinessRules);
            CreateCustomerCommand command = new();
            command.CustomerName = "Mesut";

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.Equal("Mesut", result.CustomerName);

        }

        [Fact]
        public async Task AddCustomerWhenDuplicated()
        {
            CreateCustomerCommandHandler handler = new CreateCustomerCommandHandler(_mockCustomerRepository.Object, _mapper, _CustomerBusinessRules);
            CreateCustomerCommand command = new CreateCustomerCommand();
            command.CustomerName = "Mesut";

            await Assert.ThrowsAsync<BusinessException>(async () => await handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task UpdateCustomerWhenExistsCustomer()
        {
            UpdateCustomerCommandHandler handler = new(_mockCustomerRepository.Object, _mapper);
            UpdateCustomerCommand command = new UpdateCustomerCommand();
            command.Id = 1;
            command.CustomerName = "Mesut";

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.Equal("Mesut", result.CustomerName);
        }

        [Fact]
        public async Task UpdateCustomerWhenNotExistsCustomer()
        {
            UpdateCustomerCommandHandler handler = new(_mockCustomerRepository.Object, _mapper);
            UpdateCustomerCommand command = new UpdateCustomerCommand();
            command.Id = 6;
            command.CustomerName = "Mesut";

            await Assert.ThrowsAsync<BusinessException>(async () => await handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task DeleteCustomerWhenExistsCustomer()
        {
            DeleteCustomerCommandHandler handler = new(_mockCustomerRepository.Object, _mapper);
            DeleteCustomerCommand command = new DeleteCustomerCommand();
            command.Id = 1;

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeleteCustomerWhenNotExistsCustomer()
        {
            DeleteCustomerCommandHandler handler = new(_mockCustomerRepository.Object, _mapper);
            DeleteCustomerCommand command = new DeleteCustomerCommand();
            command.Id = 6;

            await Assert.ThrowsAsync<BusinessException>(async () => await handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task GetAllCustomers()
        {
            GetListCustomerQueryHandler handler = new GetListCustomerQueryHandler(_mockCustomerRepository.Object, _mapper);
            GetListCustomerQuery query = new GetListCustomerQuery();
            query.PageRequest = new PageRequest
            {
                Page = 0,
                PageSize = 3
            };

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.Equal(2, result.Items.Count);
        }

        [Fact]
        public async Task GetByIdCustomerWhenExistsCustomer()
        {
            GetByIdCustomerQueryHandler handler = new GetByIdCustomerQueryHandler(_mockCustomerRepository.Object, _mapper);
            GetByIdCustomerQuery query = new GetByIdCustomerQuery();
            query.Id = 1;

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.Equal("Mesut", result.CustomerName);
        }

        [Fact]
        public async Task GetByIdCustomerWhenNotExistsCustomer()
        {
            GetByIdCustomerQueryHandler handler = new GetByIdCustomerQueryHandler(_mockCustomerRepository.Object, _mapper);
            GetByIdCustomerQuery query = new GetByIdCustomerQuery();
            query.Id = 6;

            await Assert.ThrowsAsync<BusinessException>(async () => await handler.Handle(query, CancellationToken.None));
        }
    }
}