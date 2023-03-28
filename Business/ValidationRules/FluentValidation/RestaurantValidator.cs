using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RestaurantValidator : AbstractValidator<Restaurant>
    {
        public RestaurantValidator()
        {
            RuleFor(r => r.WebSite).Matches(new Regex(@"\b(?:https?://|www\.)\S+\b"))
                .WithMessage("Website geçerli değil!");
        }
    }
}
