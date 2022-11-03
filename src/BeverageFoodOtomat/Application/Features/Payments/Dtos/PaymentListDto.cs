using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Payments.Dtos
{
    public class PaymentListDto
    {
        public int Id { get; set; }
        public int PaymentTotal { get; set; }
        public int PaymentTypeName { get; set; }
        public int CustomerName { get; set; }
        public int BeverageName { get; set; }
        public int FoodName { get; set; }
    }
}
