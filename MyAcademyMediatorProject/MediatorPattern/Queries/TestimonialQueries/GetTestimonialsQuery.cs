using MediatR;
using MyAcademyMediatorProject.MediatorPattern.Results;
using MyAcademyMediatorProject.MediatorPattern.Results.ProductResult;

public class GetTestimonialsQuery : IRequest<IEnumerable<GetTestimonialsQueryResult>>
{
}