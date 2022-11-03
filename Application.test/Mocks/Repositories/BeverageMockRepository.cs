
using Application.Services.Repositories;
using Core.Test.Helpers;
using Domain.Entities;
using Moq;
using System.Collections.Generic;

namespace Application.Tests.Mocks.Repositories
{
    public class BeverageMockRepository
    {
        public  Mock<IBeverageRepository> GetRepository()
        {
            var Beverages = new List<Beverage>
            {
                new Beverage
                {
                    Id = 1,
                    BeverageName =  "Meyve suyu"
                },
                new Beverage
                {
                    Id = 2,
                    BeverageName =  "Cola"
                },
            };

            return MockRepositoryHelper.GetRepository<IBeverageRepository, Beverage>(Beverages);
        }
    }
}