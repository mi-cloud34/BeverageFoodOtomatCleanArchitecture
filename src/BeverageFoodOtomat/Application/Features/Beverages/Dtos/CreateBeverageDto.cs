using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Beverages.Dtos
{
    public class CreateBeverageDto
    {
        public int Id { get; set; }
        public string BeverageName { get; set; }
        public int BeverageHotColdTypeId { get; set; }
        public int BeverageSugarFreeTypeId { get; set; }
        public int PlotNumber { get; set; }
    }
}
