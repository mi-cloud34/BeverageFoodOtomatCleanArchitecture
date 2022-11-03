using Application.Features.Payments.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Payments.Models;

public class PaymentListModel : BasePageableModel
{
    public IList<PaymentListDto> Items { get; set; }
}