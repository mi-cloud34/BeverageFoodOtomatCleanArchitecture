
using Application.Services.Repositories;
using Core.Test.Helpers;
using Domain.Entities;
using Moq;
using System.Collections.Generic;

namespace Application.Tests.Mocks.Repositories
{
    public class PaymentMockRepository
    {
        public  Mock<IPaymentRepository> GetRepository()
        {
            var Payments = new List<Payment>
            {
                new Payment
                {
                    Id = 1,
                   PaymentTotal=25,
                   PaymentTypeId =2,
                   CustomerId=1,
                   BeverageId=3,
                   FoodId=3
    },
                new Payment
                {
                    Id =2,
                    PaymentTotal=50,
                   PaymentTypeId =2,
                   CustomerId=4,
                   BeverageId=2,
                   FoodId=1
                },
            };

            return MockRepositoryHelper.GetRepository<IPaymentRepository, Payment>(Payments);
        }
    }
}