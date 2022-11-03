using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PaymentTypes.Dtos
{
    public class CreatePaymentTypeDto
    {
        public int Id { get; set; }
        public string PaymentTypeName { get; set; }
    }
}
