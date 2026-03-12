using Mapster;
using MediatR;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.MediatorPattern.Queries.CampaignQueries;
using MyAcademyMediatorProject.MediatorPattern.Results.CampaignResults;
using MyAcademyMediatorProject.Repositories;

namespace MyAcademyMediatorProject.MediatorPattern.Handlers.CampaignHandlers
{
    public class GetCampaignByIdQueryHandler : IRequestHandler<GetCampaignByIdQuery, GetCampaignsQueryResult>
    {
        private readonly IRepository<Campaign> _campaignRepository;

        public GetCampaignByIdQueryHandler(IRepository<Campaign> campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public async Task<GetCampaignsQueryResult> Handle(GetCampaignByIdQuery request, CancellationToken cancellationToken)
        {
            var campaign = await _campaignRepository.GetByIdAsync(request.Id);
            return campaign.Adapt<GetCampaignsQueryResult>();
        }
    }
}