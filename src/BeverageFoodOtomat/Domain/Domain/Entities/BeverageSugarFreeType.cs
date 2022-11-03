using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BeverageSugarFreeType:Entity
    {
        public string BeverageSugarFreeTypeName { get; set; }
        public BeverageSugarFreeType()
        {

        }
        public BeverageSugarFreeType(int id, string beverageSugarFreeTypeName) : this()
        {
            Id = id;
            BeverageSugarFreeTypeName = beverageSugarFreeTypeName;
        }
    }
}
