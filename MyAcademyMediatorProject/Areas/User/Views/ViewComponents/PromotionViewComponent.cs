using Microsoft.AspNetCore.Mvc;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.Repositories;

namespace MyAcademyMediatorProject.Areas.User.ViewComponents
{
    public class PromotionViewComponent : ViewComponent
    {
        private readonly IRepository<Campaign> _campaignRepository;

        public PromotionViewComponent(IRepository<Campaign> campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var activeCampaigns = (await _campaignRepository.GetAllAsync())
                                  .Where(c => c.IsActive)
                                  .ToList();
            return View(activeCampaigns);
        }
    }
}