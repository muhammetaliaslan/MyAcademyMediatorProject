using MediatR;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.MediatorPattern.Commands.OrderItemCommands;
using MyAcademyMediatorProject.Repositories;

namespace MyAcademyMediatorProject.MediatorPattern.Handlers.OrderItemHandlers
{
    public class RemoveOrderItemCommandHandler(IRepository<OrderItem> _repository)
        : IRequestHandler<RemoveOrderItemCommand>
    {
        public async Task Handle(RemoveOrderItemCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}