using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyMediatorProject.Models;
using MyAcademyMediatorProject.MediatorPattern.Queries.ProductQueries;
using MyAcademyMediatorProject.MediatorPattern.Queries.CampaignQueries;
using MyAcademyMediatorProject.MediatorPattern.Queries.Banner;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAcademyMediatorProject.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            var campaigns = await _mediator.Send(new GetCampaignsQuery());
            var banners = await _mediator.Send(new GetBannersQuery());

            // Slider listesi: manuel BgColor eşlemesi
            var sliders = banners
     .OrderBy(b => b.OrderNo)
     .ThenBy(b => b.Id) // 🔥 kritik ekleme
     .Select(b => new SliderItem
     {
         Title = b.Title,
         Subtitle = b.Subtitle,
         ImageUrl = b.ImageUrl,
         BgColor = b.BgColor ?? "#FFA500"
     })
     .ToList();

            // Fallback
            if (!sliders.Any())
            {
                sliders = new List<SliderItem>
                {
                    new SliderItem
                    {
                        Title = "Lezzetin En Güzel Hali",
                        Subtitle = "Günlük taze ürünlerimizle tanışın",
                        ImageUrl = "https://azim.commonsupport.com/Bagery/assets/images/banner/3f5515b1-3341-4ce9-9e07-f8b8dd024f2f.png",
                        BgColor = "#FFA500"
                    }
                };
            }

            var model = new HomeIndexViewModel
            {
                Products = products.ToList(),
                Campaigns = campaigns.ToList(),
                Sliders = sliders
            };

            return View(model);
        }
    }
}