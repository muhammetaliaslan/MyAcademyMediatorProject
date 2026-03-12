
using MediatR;

namespace MyAcademyMediatorProject.MediatorPattern.Queries.DashboardQueries
{
    

    public record GetDashboardCountsQuery : IRequest<DashboardCountsResult>;

    // MediatorPattern/Results/DashboardCountsResult.cs
    public record DashboardCountsResult(
        int CategoryCount,
        int ProductCount,
        int OrderCount,
        int PromotionCount,
        int UserCount
    );
}
