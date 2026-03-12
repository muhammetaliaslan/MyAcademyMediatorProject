using MediatR;
using MyAcademyMediatorProject.MediatorPattern.Results.OrderResults;

namespace MyAcademyMediatorProject.MediatorPattern.Queries.OrderQueries
{
    public record GetOrderByIdQuery(Guid Id) : IRequest<GetOrderByIdQueryResult>;
}