namespace MyAcademyMediatorProject.MediatorPattern.Results.OrderItemResults
{
    public record GetOrderItemsQueryResult(
     Guid Id,
     Guid OrderId,
     string OrderCustomerName,
     Guid ProductId,
     string ProductName,
     int Quantity,
     decimal UnitPrice
 );
}