using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Foods.Dtos
{
    public class CreateFoodDto
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public int FoodAqueousAnhydrousTypeId { get; set; }
        public int PlotNumber { get; set; }
    }
}
