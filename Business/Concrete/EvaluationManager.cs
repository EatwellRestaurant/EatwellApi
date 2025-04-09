using Business.Abstract;
using Business.Constants.Messages.Entity;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
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

        public async Task<IResult> Add(Evaluation evaluation)
        {
            await _evaluationDal.AddAsync(evaluation);
            return new SuccessResult(EvaluationMessages.EvaluationAdded);
        }

        public IResult Delete(Evaluation evaluation)
        {
            _evaluationDal.Remove(evaluation);
            return new SuccessResult(EvaluationMessages.EvaluationDeleted);
        }

        //public IDataResult<EvaluationDetailDto> GetEvaluationDetail(int evaluationId)
        //{
        //    return new SuccessDataResult<EvaluationDetailDto>(_evaluationDal.GetEvaluationDetail(evaluationId), EvaluationMessages.EvaluationDetailWasBrought);
        //}

        //public IDataResult<List<EvaluationDetailDto>> GetEvaluationDetails()
        //{
        //    return new SuccessDataResult<List<EvaluationDetailDto>>(_evaluationDal.GetEvaluationDetails(), EvaluationMessages.EvaluationDetailsWasBrought);
        //}
    }
}
