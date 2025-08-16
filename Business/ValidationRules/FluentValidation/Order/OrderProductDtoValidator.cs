using Entities.Concrete;
using Entities.Dtos.Order;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.Order
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
