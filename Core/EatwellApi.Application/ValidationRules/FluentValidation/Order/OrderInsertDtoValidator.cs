using Business.ValidationRules.FluentValidation.Order;
using EatwellApi.Application.Dtos.Order;
using FluentValidation;

namespace EatwellApi.Application.ValidationRules.FluentValidation.Order
{
    public class OrderInsertDtoValidator : AbstractValidator<OrderInsertDto>
    {
        public OrderInsertDtoValidator()
        {
            RuleFor(o => o.BranchId)
                .GreaterThan(0)
                .WithMessage("Lütfen şube giriniz!");


            RuleFor(o => o.TableId)
                .GreaterThan(0)
                .WithMessage("Lütfen masa giriniz!");


            RuleFor(o => o.Products)
                .Must(o => o.Count > 0)
                .WithMessage("Lütfen siparişinize en az bir ürün ekleyin.");


            RuleForEach(o => o.Products)
                .SetValidator(new OrderProductDtoValidator());

        }
    }
}
