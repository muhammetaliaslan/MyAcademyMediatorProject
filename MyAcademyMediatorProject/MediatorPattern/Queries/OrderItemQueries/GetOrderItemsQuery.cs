using MediatR;
using MyAcademyMediatorProject.MediatorPattern.Results.OrderItemResults;

namespace MyAcademyMediatorProject.MediatorPattern.Queries.OrderItemQueries
{
    public record GetOrderItemsQuery : IRequest<List<GetOrderItemsQueryResult>>;
}