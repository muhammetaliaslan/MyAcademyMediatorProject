using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyMediatorProject.Models;
using MyAcademyMediatorProject.MediatorPattern.Queries.ProductQueries;
using MyAcademyMediatorProject.MediatorPattern.Queries.CampaignQueries;
using MyAcademyMediatorProject.MediatorPattern.Queries.Banner; // Banner query ekledik
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
            // Ürünleri çek
            var products = await _mediator.Send(new GetProductsQuery());

            // Kampanyaları çek
            var campaigns = await _mediator.Send(new GetCampaignsQuery());

            // Bannerları çek (aktif olanlar)
            var banners = await _mediator.Send(new GetBannersQuery());

            // Slider listesini dinamik oluştur
            var sliders = banners.Select(b => new SliderItem
            {
                Title = b.Title,
                Subtitle = b.Subtitle,
                ImageUrl = b.ImageUrl
            }).ToList();

            // Eğer banner yoksa fallback slider
            if (!sliders.Any())
            {
                sliders = new List<SliderItem>
                {
                    new SliderItem
                    {
                        Title = "Fresh Bread Everyday",
                        Subtitle = "Welcome to Bagery Bakery",
                        ImageUrl = "/Bagery/assets/images/banner/banner-1.jpg"
                    },
                    new SliderItem
                    {
                        Title = "Delicious Cakes",
                        Subtitle = "Taste Our Special Desserts",
                        ImageUrl = "/Bagery/assets/images/banner/banner-2.jpg"
                    }
                };
            }

            var model = new HomeIndexViewModel
            {
                Products = products,
                Campaigns = campaigns,
                Sliders = sliders
            };

            return View(model);
        }
    }
}