using MediatR;
using MyAcademyMediatorProject.MediatorPattern.Results.CampaignResults;

public record GetCampaignsQuery() : IRequest<List<GetCampaignsQueryResult>>;