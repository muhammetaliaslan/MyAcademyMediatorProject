using Mapster;
using MediatR;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.MediatorPattern.Queries.OrderQueries;
using MyAcademyMediatorProject.MediatorPattern.Results.OrderResults;
using MyAcademyMediatorProject.Repositories;

namespace MyAcademyMediatorProject.MediatorPattern.Handlers.OrderHandlers
{
    public class GetOrdersQueryHandler(IRepository<Order> _orderRepository, IRepository<OrderItem> _orderItemRepository, IRepository<Product> _productRepository)
        : IRequestHandler<GetOrdersQuery, List<GetOrdersQueryResult>>
    {
        public async Task<List<GetOrdersQueryResult>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync();

            var result = new List<GetOrdersQueryResult>();
            foreach (var order in orders)
            {
                var items = await _orderItemRepository.GetAllAsync(x => x.OrderId == order.Id);
                decimal total = 0;
                foreach (var item in items)
                {
                    var product = await _productRepository.GetByIdAsync(item.ProductId);
                    total += item.Quantity * item.UnitPrice;
                }

                result.Add(new GetOrdersQueryResult(order.Id, order.CustomerName, order.CustomerEmail, order.OrderDate, total));
            }

            return result;
        }
    }
}