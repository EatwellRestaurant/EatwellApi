using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEmployeeDeductionDal : EfEntityRepositoryBase<EmployeeDeduction, RestaurantContext>, IEmployeeDeductionDal
    {
        public EfEmployeeDeductionDal(RestaurantContext context) : base(context)
        {
        }
    }
}
