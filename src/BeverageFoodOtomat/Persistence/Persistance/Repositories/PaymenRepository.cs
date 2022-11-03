using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PaymentRepository : EfRepositoryBase<Payment, BaseDbContext>, IPaymentRepository
{
    public PaymentRepository(BaseDbContext context) : base(context)
    {
    }
}