
using Application.Features.Beverages.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Beverages.Models;

public class BeverageListModel : BasePageableModel
{ 
    public IList<BeverageListDto> Items { get; set; }
}