using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.Evaluation
{
    public class EvaluationDetailDto : IDto
    {
        public int EvaluationId { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public string Message { get; set; }
    }
}
