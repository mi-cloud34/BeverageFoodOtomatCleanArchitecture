using Application.Features.BeverageSugarFreeTypes.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.BeverageSugarFreeTypes.Models;

public class BeverageSugarFreeTypeListModel : BasePageableModel
{
    public IList<BeverageSugarFreeTypeListDto> Items { get; set; }
}