using Mapster;
using MediatR;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.MediatorPattern.Queries.OrderQueries;
using MyAcademyMediatorProject.MediatorPattern.Results.OrderResults;
using MyAcademyMediatorProject.Repositories;

namespace MyAcademyMediatorProject.MediatorPattern.Handlers.OrderHandlers
{
    public class GetOrderByIdQueryHandler(IRepository<Order> _orderRepository, IRepository<OrderItem> _orderItemRepository, IRepository<Product> _productRepository)
        : IRequestHandler<GetOrderByIdQuery, GetOrderByIdQueryResult>
    {
        public async Task<GetOrderByIdQueryResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);
            var items = await _orderItemRepository.GetAllAsync(x => x.OrderId == order.Id);

            var itemResults = new List<GetOrderItemResult>();
            decimal total = 0;

            foreach (var item in items)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                itemResults.Add(new GetOrderItemResult(item.ProductId, product.Name, item.Quantity, item.UnitPrice));
                total += item.Quantity * item.UnitPrice;
            }

            return new GetOrderByIdQueryResult(order.Id, order.CustomerName, order.CustomerEmail, order.OrderDate, itemResults, total);
        }
    }
}