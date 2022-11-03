using Application.Features.BeverageHotColdTypes.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.BeverageHotColdTypes.Models;

public class BeverageHotColdTypeListModel : BasePageableModel
{
    public IList<BeverageHotColdTypeListDto> Items { get; set; }
}