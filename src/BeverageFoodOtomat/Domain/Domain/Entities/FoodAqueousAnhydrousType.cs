using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FoodAqueousAnhydrousType:Entity
    {
        public string FoodAqueousAnhydrousTypeName { get; set; }
        public FoodAqueousAnhydrousType()
        {

        }
        public FoodAqueousAnhydrousType(int id, string foodAqueousAnhydrousTypeName) : this()
        {
            Id = id;
            FoodAqueousAnhydrousTypeName = foodAqueousAnhydrousTypeName;
        }
    }
}
