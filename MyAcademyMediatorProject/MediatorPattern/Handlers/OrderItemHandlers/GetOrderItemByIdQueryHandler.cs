using Mapster;
using MediatR;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.MediatorPattern.Queries.OrderItemQueries;
using MyAcademyMediatorProject.MediatorPattern.Results.OrderItemResults;
using MyAcademyMediatorProject.Repositories;

namespace MyAcademyMediatorProject.MediatorPattern.Handlers.OrderItemHandlers
{
    public class GetOrderItemByIdQueryHandler(IRepository<OrderItem> _repository)
        : IRequestHandler<GetOrderItemByIdQuery, GetOrderItemByIdQueryResult>
    {
        public async Task<GetOrderItemByIdQueryResult> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
        {
            var orderItem = await _repository.GetByIdAsync(request.Id);
            return orderItem.Adapt<GetOrderItemByIdQueryResult>();
        }
    }
}