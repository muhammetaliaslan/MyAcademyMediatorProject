using MyAcademyMediatorProject.Context;
using Microsoft.EntityFrameworkCore;
using MyAcademyMediatorProject.Entities;

namespace MyAcademyMediatorProject.Patterns.ChainOfResponsibility
{
    public class CampaignControlHandler : OrderValidationHandler
    {
        private readonly AppDbContext _context;

        public CampaignControlHandler(AppDbContext context)
        {
            _context = context;
        }

        public override async Task Handle(Order order)
        {
            var activeCampaigns = await _context.Campaigns
                .Where(c => c.IsActive)
                .ToListAsync();

            foreach (var campaign in activeCampaigns)
            {
                if (order.TotalAmount < campaign.MinimumAmount)
                    throw new Exception($"Sipariş, kampanya '{campaign.Name}' için yeterli tutarda değil!");
            }

            await base.Handle(order);
        }
    }
}