using MyAcademyMediatorProject.MediatorPattern.Results.CategoryResults;

namespace MyAcademyMediatorProject.MediatorPattern.Results.ProductResult
{
    public record GetProductByIdQueryResult(Guid Id,
                                       string Name,
                                       decimal Price,
                                       int Stock,
                                       Guid CategoryId)
    {
    }
}
