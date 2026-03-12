using Mapster;
using MediatR;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.MediatorPattern.Queries.CategoryQueries;
using MyAcademyMediatorProject.MediatorPattern.Results.CategoryResults;
using MyAcademyMediatorProject.Repositories;

namespace MyAcademyMediatorProject.MediatorPattern.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler(IRepository<Category> _repository) : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResult>
    {
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
          var category = await _repository.GetByIdAsync(request.id);
            return category.Adapt<GetCategoryByIdQueryResult>();
        }
    }
}
  