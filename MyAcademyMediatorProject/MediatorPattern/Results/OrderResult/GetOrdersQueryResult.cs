namespace MyAcademyMediatorProject.MediatorPattern.Results.OrderResults
{
    public record GetOrdersQueryResult(
        Guid Id,
        string CustomerName,
        string CustomerEmail,
        DateTime OrderDate,
        decimal TotalPrice // Toplam tutar hesaplanacak
    );
}