using MediatR;
using MyAcademyMediatorProject.MediatorPattern.Results.OrderResults;

namespace MyAcademyMediatorProject.MediatorPattern.Queries.OrderQueries
{
    public record GetOrdersQuery : IRequest<List<GetOrdersQueryResult>>;
}