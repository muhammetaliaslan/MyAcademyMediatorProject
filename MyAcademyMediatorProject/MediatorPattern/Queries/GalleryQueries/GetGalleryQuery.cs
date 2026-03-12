using MediatR;
using MyAcademyMediatorProject.MediatorPattern.Results;
using MyAcademyMediatorProject.MediatorPattern.Results.ProductResult;

public class GetGalleryQuery : IRequest<IEnumerable<GetGalleryQueryResult>>
{
}