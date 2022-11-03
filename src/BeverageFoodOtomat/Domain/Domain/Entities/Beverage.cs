using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Beverage : Entity
    {
        public string BeverageName { get; set; }
        public int? BeverageHotColdTypeId { get; set; }
        public int? BeverageSugarFreeTypeId { get; set; }

       // public List<int> PlotNumber =new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
       public int PlotNumber { get; set; }  
        public virtual BeverageHotColdType? BeverageHotColdType {get;set;}
        public virtual BeverageSugarFreeType? BeverageSugarFreeType { get; set; }
        
        public Beverage()
        {

        }
        public Beverage(int id,string beverageName,int beverageHotColdTypeId,int beverageSugarFreeTypeId,int plotNumber):this()
        {
            Id= id;
            BeverageName= beverageName;
            BeverageHotColdTypeId= beverageHotColdTypeId;
            BeverageSugarFreeTypeId= beverageSugarFreeTypeId;
            PlotNumber= plotNumber;
        }

    }
}
