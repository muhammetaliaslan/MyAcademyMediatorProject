using MediatR;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.MediatorPattern.Commands.OrderCommands;
using MyAcademyMediatorProject.Repositories;

namespace MyAcademyMediatorProject.MediatorPattern.Handlers.OrderHandlers
{
    public class RemoveOrderCommandHandler(IRepository<Order> _orderRepository, IRepository<OrderItem> _orderItemRepository)
        : IRequestHandler<RemoveOrderCommand>
    {
        public async Task Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
        {
            // Önce itemları sil
            var orderItems = await _orderItemRepository.GetAllAsync(x => x.OrderId == request.Id);
            foreach (var item in orderItems)
            {
                await _orderItemRepository.DeleteAsync(item.Id);
            }

            // Sonra siparişi sil
            await _orderRepository.DeleteAsync(request.Id);
        }
    }
}