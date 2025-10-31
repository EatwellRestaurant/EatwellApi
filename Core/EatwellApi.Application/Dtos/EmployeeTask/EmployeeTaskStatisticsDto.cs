namespace EatwellApi.Application.Dtos.EmployeeTask
{
    public class EmployeeTaskStatisticsDto
    {
        public int TotalTaskCount { get; set; }

        public int CompletedTaskCount { get; set; }

        public int InProgressTaskCount { get; set; }

        public int PendingTaskCount { get; set; }
    }

}
