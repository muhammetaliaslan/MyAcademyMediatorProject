using Microsoft.AspNetCore.Mvc;
using MediatR;
using MyAcademyMediatorProject.MediatorPattern.Queries.CategoryQueries;
using MyAcademyMediatorProject.MediatorPattern.Queries.ProductQueries;

namespace MyAcademyMediatorProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IMediator _mediator;

        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _mediator.Send(new GetCategoriesQuery());
            var products = await _mediator.Send(new GetProductsQuery());

            ViewBag.CategoryCount = categories?.Count ?? 0;
            ViewBag.ProductCount = products?.Count ?? 0;

            // Örnek statik sayılar (daha sonra sipariş, kullanıcı ve kampanya sorgularını ekleyebilirsin)
            ViewBag.OrderCount = 12;
            ViewBag.UserCount = 34;
            ViewBag.CampaignCount = 5;

            return View();
        }
    }
}