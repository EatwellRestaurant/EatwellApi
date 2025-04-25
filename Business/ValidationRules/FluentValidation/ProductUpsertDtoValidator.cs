using Entities.Concrete;
using Entities.Dtos.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductUpsertDtoValidator : AbstractValidator<ProductUpsertDto>
    {
        public ProductUpsertDtoValidator()
        {
            RuleFor(m => m.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen ürün ismini giriniz!")
                .MaximumLength(250)
                .WithMessage("Ürün ismi en fazla 250 karakter olabilir!");


            RuleFor(p => p.Price)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen ürünün fiyat bilgisini giriniz!")
                .GreaterThan(0)
                .WithMessage("Lütfen ürünün fiyat bilgisini giriniz!");


        }
    }
}
