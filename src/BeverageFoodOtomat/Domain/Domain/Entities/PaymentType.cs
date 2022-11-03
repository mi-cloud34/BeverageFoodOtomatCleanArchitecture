using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PaymentType:Entity
    {
        public string PaymentTypeName { get; set; }
        public PaymentType()
        {

        }
        public PaymentType(int id ,string paymentTypeName) :this()
        {
            Id = id;
            PaymentTypeName = paymentTypeName;
        }
    }
}
