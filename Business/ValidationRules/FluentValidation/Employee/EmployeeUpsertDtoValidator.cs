using Entities.Dtos.Employee;
using Entities.Enums.Employee;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation.Employee
{
    public class EmployeeUpsertDtoValidator : AbstractValidator<EmployeeUpsertDto>
    {
        public EmployeeUpsertDtoValidator()
        {
            RuleFor(e => e.FirstName)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .WithMessage("Lütfen isim giriniz!")
               .MaximumLength(50)
               .WithMessage("İsim uzunluğu en fazla 50 karakter olmalıdır!");



            RuleFor(e => e.LastName)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .WithMessage("Lütfen soy isim giriniz!")
               .MaximumLength(50)
               .WithMessage("Soy isim uzunluğu en fazla 50 karakter olmalıdır!");



            RuleFor(e => e.Password)
                .NotEmpty()
                .WithMessage("Lütfen şifrenizi giriniz!");



            RuleFor(e => e.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen e-posta adresini giriniz!")
                .EmailAddress()
                .WithMessage("Lütfen geçerli bir e-posta adresi giriniz!");



            RuleFor(e => e.BranchId)
                .NotEmpty()
                .WithMessage("Lütfen şube seçiniz!");



            RuleFor(e => e.OperationClaimId)
                .NotEmpty()
                .WithMessage("Lütfen rol seçiniz!");



            RuleFor(e => e.CityId)
                .NotEmpty()
                .WithMessage("Lütfen şehir seçiniz!");



            RuleFor(e => e.Address)
                .NotEmpty()
                .WithMessage("Lütfen adres bilgisini giriniz!");



            RuleFor(e => e.Phone)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen telefon numarasını giriniz!")
                .Matches(new Regex(@"0\d{3}\ \d{3} \d{2} \d{2}"))
                .WithMessage("Lütfen geçerli bir telefon numarası giriniz!");



            RuleFor(e => e.Gender)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen cinsiyet seçiniz!")
                .Must(e => Enum.IsDefined(typeof(GenderType), e))
                .WithMessage("Geçersiz cinsiyet değeri!");



            RuleFor(e => e.EducationLevel)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen eğitim durumunu seçiniz!")
                .Must(e => Enum.IsDefined(typeof(EducationLevelType), e))
                .WithMessage("Geçersiz eğitim durumu değeri!");



            RuleFor(e => e.HireDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen işe alınma tarihini giriniz!")
                .LessThanOrEqualTo(DateTime.Today)
                .WithMessage("İşe alınma tarihi bugünden ileri bir tarih olamaz!");



            RuleFor(e => e.LeaveDate)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(e => e.HireDate)
                .When(e => e.LeaveDate.HasValue)
                .WithMessage("Ayrılma tarihi, işe alınma tarihinden sonra olmalıdır!")
                .LessThanOrEqualTo(DateTime.Today)
                .When(e => e.LeaveDate.HasValue)
                .WithMessage("Ayrılma tarihi bugünden ileri bir tarih olamaz!");



            RuleFor(e => e.WorkStatus)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen çalışma durumunu seçiniz!")
                .Must(e => Enum.IsDefined(typeof(WorkStatusType), e))
                .WithMessage("Geçersiz çalışma durumu değeri!");



            RuleFor(e => e.EmploymentType)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen istihdam türünü seçiniz!")
                .Must(e => Enum.IsDefined(typeof(EmploymentType), e))
                .WithMessage("Geçersiz istihdam türü değeri!");



            RuleFor(e => e.Salary)
                .NotEmpty()
                .WithMessage("Lütfen maaş bilgisini giriniz!");
        }
    }
}
