using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IBeverageRepository : IAsyncRepository<Beverage>, IRepository<Beverage>
{

}