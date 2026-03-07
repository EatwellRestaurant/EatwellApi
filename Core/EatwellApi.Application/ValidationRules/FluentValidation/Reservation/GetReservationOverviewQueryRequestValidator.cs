using EatwellApi.Application.Features.Queries.Reservation.GetOverview;
using FluentValidation;

namespace EatwellApi.Application.ValidationRules.FluentValidation.Reservation
{
    public class GetReservationOverviewQueryRequestValidator : AbstractValidator<GetReservationOverviewQueryRequest>
    {
        public GetReservationOverviewQueryRequestValidator()
        {
            RuleFor(g => g.BranchId)
               .GreaterThan(0)
               .WithMessage("Lütfen bir şube seçiniz!");
        }
    }
}
