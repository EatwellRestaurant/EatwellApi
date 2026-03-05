namespace EatwellApi.Application.Features.Queries.Product.GetOverview
{
    public sealed record ProductsOverviewStatistics(
        int TotalProducts,
        int ActiveProducts,
        int InactiveProducts,
        int ThisMonthAddedProducts
    );
}
