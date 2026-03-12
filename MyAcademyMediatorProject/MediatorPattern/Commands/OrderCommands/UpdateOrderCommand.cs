using MediatR;

namespace MyAcademyMediatorProject.MediatorPattern.Commands.OrderCommands
{
    public record OrderItemDto(Guid ProductId, int Quantity, decimal UnitPrice);

    public record UpdateOrderCommand(
        Guid Id,
        string CustomerName,
        string CustomerEmail,
        List<OrderItemDto> Items  // <-- burada Items ekledik
    ) : IRequest;
}