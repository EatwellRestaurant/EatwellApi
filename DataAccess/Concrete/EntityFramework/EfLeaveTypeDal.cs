using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Configurations;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLeaveTypeDal : EfEntityRepositoryBase<LeaveType, RestaurantContext>, ILeaveTypeDal
    {
        public EfLeaveTypeDal(RestaurantContext context) : base(context)
        {
        }
    }
}
