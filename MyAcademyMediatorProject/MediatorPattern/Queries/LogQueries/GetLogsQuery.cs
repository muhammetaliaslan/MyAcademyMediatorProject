using MediatR;
using MyAcademyMediatorProject.MediatorPattern.Results.LogResults;

namespace MyAcademyMediatorProject.MediatorPattern.Queries.LogQueries
{
    public class GetLogsQuery : IRequest<List<GetLogsQueryResult>>
    {
    }
}