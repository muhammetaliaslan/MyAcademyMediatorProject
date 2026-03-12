namespace MyAcademyMediatorProject.MediatorPattern.Results.OrderItemResults
{
    public record GetOrderItemByIdQueryResult(
        Guid Id,
        Guid OrderId,
        Guid ProductId,
        int Quantity,
        decimal UnitPrice,
        decimal TotalPrice
    );
}