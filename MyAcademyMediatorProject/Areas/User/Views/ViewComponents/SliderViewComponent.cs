using Microsoft.AspNetCore.Mvc;
using MediatR;
using MyAcademyMediatorProject.MediatorPattern.Queries.CampaignQueries;
using MyAcademyMediatorProject.MediatorPattern.Results.CampaignResults;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAcademyMediatorProject.Areas.User.ViewComponents
{
    [ViewComponent(Name = "Slider")]
    public class SliderViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public SliderViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var campaigns = await _mediator.Send(new GetCampaignsQuery());
            var activeCampaigns = campaigns?.FindAll(c => c.IsActive) ?? new List<GetCampaignsQueryResult>();
            return View(activeCampaigns);
        }
    }
}