using EatwellApi.Application.Dtos.Year;

namespace EatwellApi.Application.Dtos.EmployeeSalary
{
    public class EmployeeSalaryFilterOptionsDto
    {
        public List<YearListDto> YearListDtos { get; set; }

        public List<PaymentStatusDto> PaymentStatusDtos { get; set; }
    }
}
