using MediatR;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.MediatorPattern.Queries.OrderItemQueries;
using MyAcademyMediatorProject.MediatorPattern.Results.OrderItemResults;
using MyAcademyMediatorProject.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MyAcademyMediatorProject.MediatorPattern.Handlers.OrderItemHandlers
{
    public class GetOrderItemsQueryHandler : IRequestHandler<GetOrderItemsQuery, List<GetOrderItemsQueryResult>>
    {
        private readonly IRepository<OrderItem> _orderItemRepository;

        public GetOrderItemsQueryHandler(IRepository<OrderItem> orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<List<GetOrderItemsQueryResult>> Handle(GetOrderItemsQuery request, CancellationToken cancellationToken)
        {
            // Product ve Order navigation property’lerini include ediyoruz
            var orderItems = await _orderItemRepository.GetAllAsync(x => x.Product, x => x.Order);

            // Mapping
            var result = orderItems.Select(oi => new GetOrderItemsQueryResult(
                oi.Id,
                oi.OrderId,
                oi.Order != null ? oi.Order.CustomerName : "Bilinmiyor",
                oi.ProductId,
                oi.Product != null ? oi.Product.Name : "Ürün yok",
                oi.Quantity,
                oi.UnitPrice
            )).ToList();

            return result;
        }
    }
}