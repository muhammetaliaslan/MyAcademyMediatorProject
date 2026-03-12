using Mapster;
using MediatR;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.MediatorPattern.Queries.CategoryQueries;
using MyAcademyMediatorProject.MediatorPattern.Results.CategoryResults;
using MyAcademyMediatorProject.Repositories;

namespace MyAcademyMediatorProject.MediatorPattern.Handlers.CategoryHandlers
{
    public class GetCategoriesQueryHandler(IRepository<Category> repository): IRequestHandler<GetCategoriesQuery, List<GetCategoriesQueryResult>>
    {
       
        public async Task<List<GetCategoriesQueryResult>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await repository.GetAllAsync();
            return categories.Adapt<List<GetCategoriesQueryResult>>();

        }
    
    }
}
