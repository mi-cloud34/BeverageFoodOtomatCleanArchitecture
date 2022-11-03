
using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PaymentTypeRepository : EfRepositoryBase<PaymentType, BaseDbContext>,IPaymentTypeRepository
{
    public PaymentTypeRepository(BaseDbContext context) : base(context)
    {
    }
}