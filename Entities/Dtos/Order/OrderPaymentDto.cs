using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Order
{
    public class OrderPaymentDto : IDto
    {
        public byte PaymentMethod { get; set; }
    }
}
