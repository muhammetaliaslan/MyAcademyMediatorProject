using MediatR;
using MyAcademyMediatorProject.MediatorPattern.Results.OrderItemResults;

namespace MyAcademyMediatorProject.MediatorPattern.Queries.OrderItemQueries
{
    public record GetOrderItemByIdQuery(Guid Id) : IRequest<GetOrderItemByIdQueryResult>;
}