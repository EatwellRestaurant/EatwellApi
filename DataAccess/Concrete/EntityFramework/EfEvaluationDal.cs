using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEvaluationDal : EfEntityRepositoryBase<Evaluation, RestaurantContext>, IEvaluationDal
    {
        public EvaluationDetailDto GetEvaluationDetail(int evaluationId)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                var result = from e in context.Evaluations
                             join u in context.Users
                             on e.UserId equals u.Id
                             where e.Id == evaluationId
                             select new EvaluationDetailDto
                             {
                                 EvaluationId = e.Id,
                                 UserFirstName = u.FirstName,
                                 UserLastName = u.LastName,
                                 Message = e.Message
                             };
                return result.ToArray()[0];
            }
        }

        public List<EvaluationDetailDto> GetEvaluationDetails()
        {
            using(RestaurantContext context = new RestaurantContext())
            {
                var result = from e in context.Evaluations
                             join u in context.Users
                             on e.UserId equals u.Id
                             select new EvaluationDetailDto
                             {
                                 EvaluationId = e.Id,
                                 UserFirstName = u.FirstName,
                                 UserLastName = u.LastName,
                                 Message = e.Message
                             };
                return result.ToList();
            }
        }
    }
}
