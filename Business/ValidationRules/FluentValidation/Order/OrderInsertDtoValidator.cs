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


            RuleFor(o => o.PaymentMethod)
                .Cascade(CascadeMode.Stop)
                .GreaterThan((byte)0)
                .WithMessage("Lütfen ödeme yöntemini giriniz!")
                .Must(o => Enum.IsDefined(typeof(PaymentMethodEnum), o))
                .WithMessage("Geçerli bir ödeme yöntemi giriniz!");


            RuleFor(o => o.Products)
                .Must(o => o.Count > 0)
                .WithMessage("Lütfen siparişinize en az bir ürün ekleyin.");


            RuleForEach(o => o.Products)
                .SetValidator(new OrderProductDtoValidator());

        }
    }
}
