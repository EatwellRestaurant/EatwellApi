using EatwellApi.Application.Dtos.Order;
using EatwellApi.Domain.Enums;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.Order
{
    public class OrderPaymentDtoValidator : AbstractValidator<OrderPaymentDto>
    {
        public OrderPaymentDtoValidator()
        {
            RuleFor(o => o.PaymentMethod)
                .Cascade(CascadeMode.Stop)
                .GreaterThan((byte)0)
                .WithMessage("Lütfen ödeme yöntemini giriniz!")
                .Must(o => Enum.IsDefined(typeof(PaymentMethodEnum), o))
                .WithMessage("Geçerli bir ödeme yöntemi giriniz!");
        }
    }
}
