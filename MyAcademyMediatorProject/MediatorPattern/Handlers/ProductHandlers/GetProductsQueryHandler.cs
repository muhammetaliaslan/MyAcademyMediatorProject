using Mapster;
using MediatR;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.MediatorPattern.Queries.ProductQueries;
using MyAcademyMediatorProject.MediatorPattern.Results.ProductResult;
using MyAcademyMediatorProject.Repositories;

namespace MyAcademyMediatorProject.MediatorPattern.Handlers.ProductHandlers
{
    public class GetProductsQueryHandler(IRepository<Product> _repository) : IRequestHandler<GetProductsQuery,List<GetProductsQueryResult>>
    {
        public async Task<List<GetProductsQueryResult>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync(x=>x.Category);

            return products.Adapt<List<GetProductsQueryResult>>();


        }
    }
}
