using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Food:Entity
    {
        public string FoodName { get; set; }
        public int FoodAqueousAnhydrousTypeId { get; set; }
        public int PlotNumber { get; set; }
        public virtual FoodAqueousAnhydrousType? FoodAqueousAnhydrousType { get; set; }
      

        public Food()
        {

        }
        public Food(int id, string foodName, int foodAqueousAnhydrousTypeId,  int plotNumber) : this()
        {
            Id = id;
            FoodName = foodName;
            FoodAqueousAnhydrousTypeId = foodAqueousAnhydrousTypeId;
            PlotNumber = plotNumber;
        }
    }
}
