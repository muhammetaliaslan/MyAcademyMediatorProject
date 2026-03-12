using MediatR;
using MyAcademyMediatorProject.MediatorPattern.Results.CampaignResults;

namespace MyAcademyMediatorProject.MediatorPattern.Queries.CampaignQueries
{
    public class GetCampaignByIdQuery : IRequest<GetCampaignsQueryResult>
    {
        public Guid Id { get; set; }

        public GetCampaignByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}