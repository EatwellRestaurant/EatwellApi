using Business.ValidationRules.FluentValidation.ShiftDay;
using Entities.Dtos.Employee;
using Entities.Enums.Employee;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Linq;
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



            RuleFor(e => e.OperationClaimId)
                .NotEmpty()
                .WithMessage("Lütfen rol seçiniz!");



            RuleFor(e => e.CityId)
                .NotEmpty()
                .WithMessage("Lütfen şehir seçiniz!");



            RuleFor(e => e.NationalId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen TC Kimlik numarasını giriniz!")
                .Length(11)
                .WithMessage("TC Kimlik numarası 11 haneli olmalıdır!")
                .Matches("^[1-9][0-9]{10}$")
                .WithMessage("Geçerli bir TC Kimlik numarası giriniz!");



            RuleFor(e => e.BirthDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen doğum tarihini giriniz!")
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Doğum tarihi bugünden büyük olamaz!");



            RuleFor(e => e.MaritalStatus)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen medeni durum seçiniz!")
                .Must(e => Enum.IsDefined(typeof(MaritalStatus), e))
                .WithMessage("Geçerli bir medeni durum seçiniz!");



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
                .WithMessage("Geçerli bir cinsiyet seçiniz!");



            RuleFor(e => e.EducationLevel)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen eğitim durumunu seçiniz!")
                .Must(e => Enum.IsDefined(typeof(EducationLevelType), e))
                .WithMessage("Geçerli bir eğitim durumu seçiniz!");



            When(e => e.Gender != GenderType.Female, () =>
            {
                RuleFor(e => e.MilitaryStatus)
                    .NotEmpty()
                    .WithMessage("Lütfen askerlik durumunu seçiniz!")
                    .Must(e => e.HasValue && Enum.IsDefined(typeof(MilitaryStatus), e.Value))
                    .WithMessage("Geçerli bir askerlik durumu seçiniz!");
            });



            RuleFor(e => e.HireDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen işe alınma tarihini giriniz!")
                .LessThanOrEqualTo(DateTime.Today)
                .WithMessage("İşe alınma tarihi bugünden ileri bir tarih olamaz!");



            RuleFor(e => e.WorkStatus)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen çalışma durumunu seçiniz!")
                .Must(e => Enum.IsDefined(typeof(WorkStatusType), e))
                .WithMessage("Geçerli bir çalışma durumu seçiniz!");



            RuleFor(e => e.LeaveDate)
                .NotEmpty()
                .When(e => e.WorkStatus == WorkStatusType.Resigned)
                .WithMessage("İşten ayrılan çalışanlar için ayrılma tarihi zorunludur!");



            RuleFor(e => e.LeaveDate)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(e => e.HireDate)
                .When(e => e.LeaveDate.HasValue)
                .WithMessage("Ayrılma tarihi, işe alınma tarihinden sonra olmalıdır!")
                .LessThanOrEqualTo(DateTime.Today)
                .When(e => e.LeaveDate.HasValue)
                .WithMessage("Ayrılma tarihi bugünden ileri bir tarih olamaz!");



            RuleFor(e => e.EmploymentType)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen istihdam türünü seçiniz!")
                .Must(e => Enum.IsDefined(typeof(EmploymentType), e))
                .WithMessage("Geçerli bir istihdam türü seçiniz!");



            RuleFor(e => e.Salary)
                .NotEmpty()
                .WithMessage("Lütfen maaş bilgisini giriniz!");



            RuleFor(s => s.ShiftDayDtos)
                .Must(s => s.Count > 0)
                .WithMessage("Vardiya listesi boş olamaz!");



            RuleForEach(s => s.ShiftDayDtos)
                .SetValidator(new ShiftDayDtoValidator());
        }


        private bool BeAValidImage(IFormFile? file)
        {
            string[] allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };
         
            string? extension = Path.GetExtension(file?.FileName)?.ToLower();
            
            return allowedExtensions.Contains(extension);
        }
    }
}
