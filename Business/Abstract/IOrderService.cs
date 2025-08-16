using Core.ResponseModels;
using Entities.Concrete;
using Entities.Dtos.Order;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService : IService<Order>
    {
        Task<CreateSuccessResponse> Add(OrderInsertDto orderInsertDto);
    }
}
