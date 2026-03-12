using MyAcademyMediatorProject.Context;
using MyAcademyMediatorProject.Entities;

namespace MyAcademyMediatorProject.Patterns.Observer
{
    public class OrderCreatedLogObserver : IOrderObserver
    {
        private readonly AppDbContext _context;

        public OrderCreatedLogObserver(AppDbContext context)
        {
            _context = context;
        }

        public async Task Notify(Order order)
        {
            var log = new Log
            {
                ActionType = "Order",
                Description = $"Order ID {order.Id} created. Customer: {order.CustomerEmail}"
            };

            _context.Logs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}