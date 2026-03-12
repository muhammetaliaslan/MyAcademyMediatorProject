using MediatR;

namespace MyAcademyMediatorProject.MediatorPattern.Commands.OrderItemCommands
{
    public class CreateOrderItemCommand : IRequest
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}