using EatwellApi.Application.Dtos.Product;
using FluentValidation;

namespace EatwellApi.Application.ValidationRules.FluentValidation.Product
{
    public class ProductUpsertDtoValidator : AbstractValidator<ProductUpsertDto>
    {
        public ProductUpsertDtoValidator()
        {
            RuleFor(p => p.Name)
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
