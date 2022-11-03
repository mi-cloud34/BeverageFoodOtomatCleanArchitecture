using Application.Features.FoodAqueousAnhydrousTypes.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.FoodAqueousAnhydrousTypes.Models;

public class FoodAqueousAnhydrousTypesListModel : BasePageableModel
{
    public IList<FoodAqueousAnhydrousTypeListDto> Items { get; set; }
}