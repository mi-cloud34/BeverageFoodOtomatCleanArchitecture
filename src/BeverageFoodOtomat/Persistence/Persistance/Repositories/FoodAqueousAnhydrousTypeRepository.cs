
using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class FoodAqueousAnhydrousTypeRepository : EfRepositoryBase<FoodAqueousAnhydrousType, BaseDbContext>, IFoodAqueousAnhydrousTypeRepository
{
    public FoodAqueousAnhydrousTypeRepository(BaseDbContext context) : base(context)
    {
    }
}