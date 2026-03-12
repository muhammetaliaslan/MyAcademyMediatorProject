using MediatR;
using MyAcademyMediatorProject.MediatorPattern.Results.CategoryResults;

namespace MyAcademyMediatorProject.MediatorPattern.Queries.CategoryQueries;

public record GetCategoryByIdQuery(Guid id): IRequest<GetCategoryByIdQueryResult>;

