
using Application.Services.Repositories;
using Core.Test.Helpers;
using Domain.Entities;
using Moq;
using System.Collections.Generic;

namespace Application.Tests.Mocks.Repositories
{
    public class  PaymentTypeMockRepository
    {
        public  Mock<IPaymentTypeRepository> GetRepository()
        {
            var  PaymentTypes = new List< PaymentType>
            {
                new  PaymentType
                {
                    Id = 1,
                     PaymentTypeName =  "Cash"
                },
                new  PaymentType
                {
                    Id = 2,
                     PaymentTypeName =  "Credi"
                },
            };

            return MockRepositoryHelper.GetRepository<IPaymentTypeRepository,  PaymentType>( PaymentTypes);
        }
    }
}