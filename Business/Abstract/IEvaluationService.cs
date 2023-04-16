using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEvaluationService
    {
        IResult Add(Evaluation evaluation);
        IResult Delete(Evaluation evaluation);
        IDataResult<EvaluationDetailDto> GetEvaluationDetail(int evaluationId);
        IDataResult<List<EvaluationDetailDto>> GetEvaluationDetails();
    }
}
