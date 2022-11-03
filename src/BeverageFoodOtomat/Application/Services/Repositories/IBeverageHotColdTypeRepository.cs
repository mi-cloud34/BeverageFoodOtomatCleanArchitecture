using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IBeverageHotColdTypeRepository : IAsyncRepository<BeverageHotColdType>, IRepository<BeverageHotColdType>
{

}