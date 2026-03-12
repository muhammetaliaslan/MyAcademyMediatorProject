// Areas/Admin/Controllers/CampaignController.cs
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyMediatorProject.MediatorPattern.Commands.CampaignCommands;
using MyAcademyMediatorProject.MediatorPattern.Queries.CampaignQueries;

namespace MyAcademyMediatorProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CampaignController : Controller
    {
        private readonly IMediator _mediator;

        public CampaignController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var campaigns = await _mediator.Send(new GetCampaignsQuery());
            return View(campaigns);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCampaignCommand command)
        {
            if (!ModelState.IsValid)
                return View(command);

            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var value = await _mediator.Send(new GetCampaignByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCampaignCommand command)
        {
            if (!ModelState.IsValid)
                return View(command);

            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new RemoveCampaignCommand(id));
            return RedirectToAction("Index");
        }
    }
}