using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Order
{
    public class OrderInsertDto : IDto
    {
        public int BranchId { get; set; }

        public int TableId { get; set; }

        public int? ReservationId { get; set; }

        public List<OrderProductDto> Products { get; set; }

    }
}
