using Castle.Core.Internal;
using Entities.Concrete;
using Entities.Dtos.Branch;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BranchUpsertDtoValidator : AbstractValidator<BranchUpsertDto>
    {
        public BranchUpsertDtoValidator()
        {
            RuleFor(b => b.CityId)
                .NotEmpty()
                .WithMessage("Lütfen bir şehir seçiniz!");
            
            
            RuleFor(b => b.Name)
                .NotEmpty()
                .WithMessage("Lütfen şube ismini giriniz!");
            

            RuleFor(b => b.Address)
                .NotEmpty()
                .WithMessage("Lütfen şubenin adresini giriniz!");
            
            
            RuleFor(b => b.Email)
                .NotEmpty()
                .WithMessage("Lütfen şubenin adresini giriniz!");


            RuleFor(b => b.Phone)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen şubenin telefon numarasını giriniz!")
                .Matches(new Regex(@"0\d{3}\ \d{3} \d{2} \d{2}"))
                .WithMessage("Lütfen geçerli bir telefon numarası giriniz!");
                

            RuleFor(b => b.WebSite)
                .Matches(new Regex(@"\b(?:https?://|www\.)\S+\b"))
                .When(b => !b.WebSite.IsNullOrEmpty())
                .WithMessage("Lütfen geçerli bir web site adresi giriniz!");


            RuleFor(b => b.Facebook)
                .Matches(new Regex(@"^(https?:\/\/)?www\."))
                .When(b => !b.Facebook.IsNullOrEmpty())
                .WithMessage("Lütfen https://www. veya http://www. ile başlayan bir adres giriniz!");


            RuleFor(b => b.Instagram)
                .Matches(new Regex(@"^(https?:\/\/)?www\."))
                .When(b => !b.Instagram.IsNullOrEmpty())
                .WithMessage("Lütfen https://www. veya http://www. ile başlayan bir adres giriniz!");


            RuleFor(b => b.Twitter)
                .Matches(new Regex(@"^(https?:\/\/)?www\."))
                .When(b => !b.Twitter.IsNullOrEmpty())
                .WithMessage("Lütfen https://www. veya http://www. ile başlayan bir adres giriniz!");
            

            RuleFor(b => b.Gmail)
                .Matches(new Regex(@"^(https?:\/\/)?www\."))
                .When(b => !b.Gmail.IsNullOrEmpty())
                .WithMessage("Lütfen https://www. veya http://www. ile başlayan bir adres giriniz!");
        }
    }
}
