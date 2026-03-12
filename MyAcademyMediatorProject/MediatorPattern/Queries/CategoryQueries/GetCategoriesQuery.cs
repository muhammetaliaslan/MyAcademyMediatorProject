using MediatR;
using MyAcademyMediatorProject.MediatorPattern.Results.CategoryResults;

namespace MyAcademyMediatorProject.MediatorPattern.Queries.CategoryQueries
{
    public record GetCategoriesQuery: IRequest<List<GetCategoriesQueryResult>>
    {

    }
}
