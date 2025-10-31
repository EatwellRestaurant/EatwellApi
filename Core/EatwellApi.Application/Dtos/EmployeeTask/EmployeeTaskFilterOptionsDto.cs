using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.EmployeeTask
{
    public class EmployeeTaskFilterOptionsDto : IDto
    {
        public List<PriorityLevelDto> PriorityLevelDtos { get; set; }

        public List<TaskStatusDto> TaskStatusDtos { get; set; }
    }
}
