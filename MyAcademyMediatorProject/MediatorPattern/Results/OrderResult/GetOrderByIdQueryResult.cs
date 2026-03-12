namespace MyAcademyMediatorProject.MediatorPattern.Results.OrderResults
{
    public record GetOrderByIdQueryResult(
        Guid Id,
        string CustomerName,
        string CustomerEmail,
        DateTime OrderDate,
        List<GetOrderItemResult> Items,
        decimal TotalAmount
    );

    public record GetOrderItemResult(
        Guid ProductId,
        string ProductName,
        int Quantity,
        decimal UnitPrice
    );
}