using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Payment:Entity
    {
        public int PaymentTotal { get; set; }
        public int PaymentTypeId { get; set; }
        public int CustomerId { get; set; }
        public int BeverageId { get; set; }
        public int FoodId { get; set; }

        public virtual PaymentType PaymentType { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Beverage Beverage { get; set; }
        public virtual Food Food { get; set; }

        public Payment()
        {

        }
        public Payment(int id,int paymentTotal,int paymentTypeId, int customerId,int beverageId,int foodId)
        {
            Id = id;
            PaymentTotal = paymentTotal;
            PaymentTypeId = paymentTypeId;
            CustomerId = customerId;
            BeverageId= beverageId;
            FoodId = foodId;    


        }
    }
}
