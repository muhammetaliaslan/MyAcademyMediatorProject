using Mapster;
using MediatR;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.MediatorPattern.Queries.ProductQueries;
using MyAcademyMediatorProject.MediatorPattern.Results.ProductResult;
using MyAcademyMediatorProject.Repositories;


namespace MyAcademyMediatorProject.MediatorPattern.Handlers.ProductHandlers
{
    public class GetProductByIdQueryHandler(IRepository<Product> _repository) : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResult>
    {
        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);
            return product.Adapt<GetProductByIdQueryResult>();
        }
    }
}
 