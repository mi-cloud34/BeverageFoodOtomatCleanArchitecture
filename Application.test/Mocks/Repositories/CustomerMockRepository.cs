
using Application.Services.Repositories;
using Core.Test.Helpers;
using Domain.Entities;
using Moq;
using System.Collections.Generic;

namespace Application.Tests.Mocks.Repositories
{
    public class CustomerMockRepository
    {
        public  Mock<ICustomerRepository> GetRepository()
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    CustomerName =  "Mesut"
                },
                new Customer
                {
                    Id = 2,
                    CustomerName =  "Güney"
                },
            };

            return MockRepositoryHelper.GetRepository<ICustomerRepository, Customer>(customers);
        }
    }
}