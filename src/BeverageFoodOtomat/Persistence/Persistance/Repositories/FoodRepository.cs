using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class FoodRepository : EfRepositoryBase<Food, BaseDbContext>, IFoodRepository
{
    public FoodRepository(BaseDbContext context) : base(context)
    {
    }
}