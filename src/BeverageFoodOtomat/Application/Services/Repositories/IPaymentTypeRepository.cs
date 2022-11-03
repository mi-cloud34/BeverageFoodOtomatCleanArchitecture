using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IPaymentTypeRepository : IAsyncRepository<PaymentType>, IRepository<PaymentType>
{

}