using MyAcademyMediatorProject.Context;
using Microsoft.EntityFrameworkCore;
using MyAcademyMediatorProject.Entities;

namespace MyAcademyMediatorProject.Patterns.ChainOfResponsibility
{
    public class StockControlHandler : OrderValidationHandler
    {
        private readonly AppDbContext _context;

        public StockControlHandler(AppDbContext context)
        {
            _context = context;
        }

        public override async Task Handle(Order order)
        {
            var orderItems = await _context.OrderItems
                .Include(oi => oi.Product)
                .Where(oi => oi.OrderId == order.Id)
                .ToListAsync();

            foreach (var item in orderItems)
            {
                if (item.Product.Stock < item.Quantity)
                    throw new Exception($"Ürün '{item.Product.Name}' için yeterli stok yok!");
            }

            await base.Handle(order);
        }
    }
}