using Mapster;
using MediatR;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.MediatorPattern.Commands.OrderCommands;
using MyAcademyMediatorProject.Repositories;

namespace MyAcademyMediatorProject.MediatorPattern.Handlers.OrderHandlers
{
    public class UpdateOrderCommandHandler(IRepository<Order> _orderRepository, IRepository<OrderItem> _orderItemRepository)
        : IRequestHandler<UpdateOrderCommand>
    {
        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);
            order.CustomerName = request.CustomerName;
            order.CustomerEmail = request.CustomerEmail;

            await _orderRepository.UpdateAsync(order);

            // Önce mevcut itemları sil
            var existingItems = await _orderItemRepository.GetAllAsync(x => x.OrderId == order.Id);
            foreach (var item in existingItems)
            {
                await _orderItemRepository.DeleteAsync(item.Id);
            }

            // Yeni itemları ekle
            foreach (var item in request.Items)
            {
                var orderItem = new OrderItem
                {
                    Id = Guid.NewGuid(),
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                };
                await _orderItemRepository.CreateAsync(orderItem);
            }
        }
    }
}