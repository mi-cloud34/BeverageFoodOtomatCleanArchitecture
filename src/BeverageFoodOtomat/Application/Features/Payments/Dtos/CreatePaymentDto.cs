using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Payments.Dtos
{
    public class CreatePaymentDto
    {
        public int Id { get; set; }
        public int PaymentTotal { get; set; }
        public int PaymentTypeId { get; set; }
        public int CustomerId { get; set; }
        public int BeverageId { get; set; }
        public int FoodId { get; set; }
    }
}
