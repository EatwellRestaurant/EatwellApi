using EatwellApi.Application.Abstractions.Repositories;
using EatwellApi.Application.Dtos.User;
using EatwellApi.Application.Extensions;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Enums.OperationClaim;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DomainUser = EatwellApi.Domain.Entities.User;

namespace EatwellApi.Application.Features.Queries.User.GetOverview
{
    public class GetUsersOverviewQueryHandler : IRequestHandler<GetUsersOverviewQueryRequest, DataResponse<UsersOverviewDto>>
    {
        readonly IUserReadRepository _readRepository;

        public GetUsersOverviewQueryHandler(IUserReadRepository readRepository)
        {
            _readRepository = readRepository;
        }



        public async Task<DataResponse<UsersOverviewDto>> Handle(GetUsersOverviewQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<DomainUser> query = _readRepository
                .Where(u => u.OperationClaimId == (int)OperationClaimEnum.User && !u.IsDeleted)
                .AsNoTracking();


            DateTime now = DateTime.UtcNow;

            UsersOverviewStatistics statistics = await query
            .GroupBy(_ => 1)
            .Select(g => new UsersOverviewStatistics(
                g.Count(),
                g.Count(u => u.Verification == true),
                g.Count(u => u.Verification != true),
                g.Count(u =>
                    u.CreateDate.Month == now.Month &&
                    u.CreateDate.Year == now.Year),
                g.Count(u => EF.Functions.DateDiffDay(u.LastLoginDate, now) <= 14),
                g.Count(u => 
                    EF.Functions.DateDiffDay(u.LastLoginDate, now) > 14 &&
                    EF.Functions.DateDiffDay(u.LastLoginDate, now) <= 30),
                g.Count(u => EF.Functions.DateDiffDay(u.LastLoginDate, now) > 30)
            ))
            .SingleAsync(cancellationToken);


            List<UserListDto> users = await query
                .ApplyPagination(request)
                .Select(u => new UserListDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Verification = u.Verification,
                    CreateDate = u.CreateDate
                })
                .ToListAsync();


            return new(new()
            {
                TotalUsers = statistics.TotalUsers,
                VerifiedUsers = statistics.VerifiedUsers,
                UnverifiedUsers = statistics.UnverifiedUsers,
                ThisMonthRegisteredUsers = statistics.ThisMonthRegisteredUsers,
                UserChurnTrend = new()
                {
                    ActiveUsersCount = statistics.ActiveUsersCount,
                    AtRiskUsersCount = statistics.AtRiskUsersCount,
                    ChurnedUsersCount = statistics.ChurnedUsersCount 
                },
                Users = new(users, request, statistics.TotalUsers)
            });
        }
    }
}
