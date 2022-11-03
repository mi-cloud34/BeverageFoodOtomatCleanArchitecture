
using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BeverageHotColdTypeRepository : EfRepositoryBase<BeverageHotColdType, BaseDbContext>,IBeverageHotColdTypeRepository
{
    public BeverageHotColdTypeRepository(BaseDbContext context) : base(context)
    {
    }
}