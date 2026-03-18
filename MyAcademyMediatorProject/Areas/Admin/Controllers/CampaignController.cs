
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyMediatorProject.MediatorPattern.Commands.CampaignCommands;
using MyAcademyMediatorProject.MediatorPattern.Queries.CampaignQueries;
using MyAcademyMediatorProject.MediatorPattern.Queries.ProductQueries;
using MyAcademyMediatorProject.MediatorPattern.Queries.CategoryQueries;

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

        // Dropdownları doldurmak için
        private async Task GetCategoriesAndProductsAsync()
        {
            var categories = await _mediator.Send(new GetCategoriesQuery());
            ViewBag.Categories = categories
                .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() })
                .ToList();

            var products = await _mediator.Send(new GetProductsQuery());
            ViewBag.Products = products
                .Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() })
                .ToList();
        }

        public async Task<IActionResult> Index()
        {
            var campaigns = await _mediator.Send(new GetCampaignsQuery());
            return View(campaigns);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await GetCategoriesAndProductsAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCampaignCommand command)
        {
            if (!ModelState.IsValid)
            {
                await GetCategoriesAndProductsAsync();
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var campaign = await _mediator.Send(new GetCampaignByIdQuery(id));
            await GetCategoriesAndProductsAsync();
            return View(campaign);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCampaignCommand command)
        {
            if (!ModelState.IsValid)
            {
                await GetCategoriesAndProductsAsync();
                return View(command);
            }

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