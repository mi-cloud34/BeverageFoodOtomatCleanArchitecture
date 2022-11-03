using Application.Features.Foods.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Foods.Models;

public class FoodListModel : BasePageableModel
{
    public IList<FoodListDto> Items { get; set; }
}