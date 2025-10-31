using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.OperationClaim
{
    public class OperationClaimListDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
