using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Beverages.Dtos
{
    public class BeverageListDto
    {
        public int Id { get; set; }
        public string BeverageName { get; set; }
        public string BeverageHotColdName { get; set; }
        public string BeverageSugarFreeName { get; set; }
        public int PlotNumber { get; set; }
    }
}
