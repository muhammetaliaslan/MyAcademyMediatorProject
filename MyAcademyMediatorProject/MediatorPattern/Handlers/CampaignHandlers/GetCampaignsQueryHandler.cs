using MediatR;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.MediatorPattern.Results.CampaignResults;
using MyAcademyMediatorProject.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class GetCampaignsQueryHandler : IRequestHandler<GetCampaignsQuery, List<GetCampaignsQueryResult>>
{
    private readonly IRepository<Campaign> _repository;

    public GetCampaignsQueryHandler(IRepository<Campaign> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetCampaignsQueryResult>> Handle(GetCampaignsQuery request, CancellationToken cancellationToken)
    {
        // Tüm aktif kampanyaları çek
        var campaigns = await _repository.GetAllAsync(); // veya includes ile ilişkili veriler eklenebilir
        var activeCampaigns = campaigns
            .Where(c => c.IsActive)
            .Select(c => new GetCampaignsQueryResult(
                c.Id,
                c.Name,
                c.Description,
                c.Discount,
                c.MinimumAmount,
                c.StartDate,
                c.EndDate,
                c.IsActive
            )
            {
                ImageUrl = c.ImageUrl // veritabanındaki resim alanı
            })
            .ToList();

        return activeCampaigns;
    }
}