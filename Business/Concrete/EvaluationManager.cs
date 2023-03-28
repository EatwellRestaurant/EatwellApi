using Business.Abstract;
using Business.Constants.Messages.Entity;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EvaluationManager : IEvaluationService
    {
        private IEvaluationDal _evaluationDal;

        public EvaluationManager(IEvaluationDal evaluationDal)
        {
            _evaluationDal = evaluationDal;
        }

        public IResult Add(Evaluation evaluation)
        {
            _evaluationDal.Add(evaluation);
            return new SuccessResult(EvaluationMessages.EvaluationAdded);
        }

        public IResult Delete(Evaluation evaluation)
        {
            _evaluationDal.Delete(evaluation);
            return new SuccessResult(EvaluationMessages.EvaluationDeleted);
        }
    }
}
