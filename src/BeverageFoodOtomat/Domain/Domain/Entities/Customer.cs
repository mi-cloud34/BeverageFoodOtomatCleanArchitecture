using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer:Entity
    {
        public string CustomerName { get; set; }
        public Customer()
        {

        }
        public Customer(int id,string customerName):this()
        {
            Id = id;
            CustomerName = customerName;
        }
        
    }
}
