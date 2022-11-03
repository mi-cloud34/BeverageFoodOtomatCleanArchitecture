
using Application.Features.PaymentTypes.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.PaymentTypes.Models;

public class PaymentTypeListModel : BasePageableModel
{
    public IList<PaymentTypeListDto> Items { get; set; }
}