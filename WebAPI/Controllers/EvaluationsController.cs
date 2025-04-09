using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EvaluationsController : ControllerBase
    {
        private IEvaluationService _evaluationService;

        public EvaluationsController(IEvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Evaluation evaluation)
        {
            var result = await _evaluationService.Add(evaluation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(Evaluation evaluation)
        {
            var result = _evaluationService.Delete(evaluation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpGet]
        //public IActionResult GetEvaluationDetail(int evaluationId)
        //{
        //    var result = _evaluationService.GetEvaluationDetail(evaluationId);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        //[HttpGet]
        //public IActionResult GetEvaluationDetails()
        //{
        //    var result = _evaluationService.GetEvaluationDetails();
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
    }
}
