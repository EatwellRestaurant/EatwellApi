using EatwellApi.Application.Dtos.Order;
using FluentValidation;

namespace EatwellApi.Application.ValidationRules.FluentValidation.Order
{
    public class OrderProductDtoValidator : AbstractValidator<OrderProductDto>
    {
        public OrderProductDtoValidator()
        {
            RuleFor(o => o.ProductId)
                .GreaterThan(0)
                .WithMessage("Lütfen ürün giriniz!");


            RuleFor(o => o.Quantity)
                .GreaterThan(0)
                .WithMessage("Lütfen ürün miktarını giriniz!");
        }
    }
}
