using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAcademyMediatorProject.Context;
using MyAcademyMediatorProject.MediatorPattern.Queries.LogQueries;
using MyAcademyMediatorProject.MediatorPattern.Results.LogResults;

namespace MyAcademyMediatorProject.MediatorPattern.Handlers.LogHandlers
{
    public class GetLogsQueryHandler : IRequestHandler<GetLogsQuery, List<GetLogsQueryResult>>
    {
        private readonly AppDbContext _context;

        public GetLogsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetLogsQueryResult>> Handle(GetLogsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Logs
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => new GetLogsQueryResult
                {
                    ActionType = x.ActionType,
                    Description = x.Description,
                    CreatedDate = x.CreatedDate
                }).ToListAsync();
        }
    }
}