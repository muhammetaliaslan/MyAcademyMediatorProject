using Mapster;
using MediatR;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.MediatorPattern.Commands.OrderItemCommands;
using MyAcademyMediatorProject.Repositories;

namespace MyAcademyMediatorProject.MediatorPattern.Handlers.OrderItemHandlers
{
    public class CreateOrderItemCommandHandler(IRepository<OrderItem> _repository)
        : IRequestHandler<CreateOrderItemCommand>
    {
        public async Task Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = request.Adapt<OrderItem>();
            await _repository.CreateAsync(orderItem);
        }
    }
}