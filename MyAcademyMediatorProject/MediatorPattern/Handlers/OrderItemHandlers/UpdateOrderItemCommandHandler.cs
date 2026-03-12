using Mapster;
using MediatR;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.MediatorPattern.Commands.OrderItemCommands;
using MyAcademyMediatorProject.Repositories;

namespace MyAcademyMediatorProject.MediatorPattern.Handlers.OrderItemHandlers
{
    public class UpdateOrderItemCommandHandler(IRepository<OrderItem> _repository)
        : IRequestHandler<UpdateOrderItemCommand>
    {
        public async Task Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = request.Adapt<OrderItem>();
            await _repository.UpdateAsync(orderItem);
        }
    }
}