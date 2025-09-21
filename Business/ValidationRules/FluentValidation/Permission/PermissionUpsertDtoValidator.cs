using Entities.Dtos.Permission;
using Entities.Enums.Employee;
using Entities.Enums.Permission;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.Permission
{
    public class PermissionUpsertDtoValidator : AbstractValidator<PermissionUpsertDto>
    {
        public PermissionUpsertDtoValidator()
        {
            RuleFor(p => p.LeaveTypeId)
                 .Cascade(CascadeMode.Stop)
                 .NotEmpty()
                 .WithMessage("Lütfen izin türünü seçiniz!")
                 .Must(p => Enum.IsDefined(typeof(LeaveTypeEnum), p))
                 .WithMessage("Geçerli bir izin türü seçiniz!");



            RuleFor(p => p.StartDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen izin başlangıç tarihini giriniz!")
                .Must(d => d.Date >= DateTime.Now.Date)
                .WithMessage("İzin başlangıç tarihi bugünden erken olamaz!");
            
            
            
            RuleFor(p => p.EndDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen izin bitiş tarihini giriniz!")
                .GreaterThanOrEqualTo(p => p.StartDate)
                .WithMessage("İzin bitiş tarihi, izin başlangıç tarihinden erken olamaz!");



            RuleFor(p => p.Description)
                 .MaximumLength(500)
                 .WithMessage("Açıklama 500 karakterden uzun olamaz!");
        }
    }
}
