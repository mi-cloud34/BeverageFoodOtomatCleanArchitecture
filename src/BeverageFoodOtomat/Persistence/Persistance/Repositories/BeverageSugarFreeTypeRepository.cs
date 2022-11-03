using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BeverageSugarFreeTypeRepository : EfRepositoryBase<BeverageSugarFreeType, BaseDbContext>, IBeverageSugarFreeTypeRepository
{
    public BeverageSugarFreeTypeRepository(BaseDbContext context) : base(context)
    {
    }
}