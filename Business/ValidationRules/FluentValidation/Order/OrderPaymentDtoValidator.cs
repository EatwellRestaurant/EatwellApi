using Entities.Dtos.Order;
using Entities.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
