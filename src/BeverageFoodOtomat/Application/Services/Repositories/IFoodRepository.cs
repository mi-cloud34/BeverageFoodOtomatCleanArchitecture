using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IFoodRepository : IAsyncRepository<Food>, IRepository<Food>
{

}