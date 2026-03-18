using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MyAcademyMediatorProject.MediatorPattern.Commands.BannerCommands;
using MyAcademyMediatorProject.MediatorPattern.Queries.Banner;

namespace MyAcademyMediatorProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannerController : Controller
    {
        private readonly IMediator _mediator;

        public BannerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: Admin/Banner
        public async Task<IActionResult> Index()
        {
            var banners = await _mediator.Send(new GetBannersQuery());
            return View(banners);
        }

        // GET: Admin/Banner/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Banner/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBannerCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }
    }
}