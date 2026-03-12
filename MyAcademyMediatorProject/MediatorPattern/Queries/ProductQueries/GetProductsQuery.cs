using MediatR;
using MyAcademyMediatorProject.MediatorPattern.Results.ProductResult;

namespace MyAcademyMediatorProject.MediatorPattern.Queries.ProductQueries;

    public record GetProductsQuery: IRequest<List<GetProductsQueryResult>>;
 