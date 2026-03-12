using Microsoft.AspNetCore.Mvc;
using MediatR;
using MyAcademyMediatorProject.MediatorPattern.Queries.CampaignQueries;
using MyAcademyMediatorProject.MediatorPattern.Queries.ProductQueries;
using MyAcademyMediatorProject.Models;

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
            var campaigns = await _mediator.Send(new GetCampaignsQuery());
            var products = await _mediator.Send(new GetProductsQuery());
            Console.WriteLine($"Kampanya sayısı: {campaigns.Count}");
            Console.WriteLine($"Ürün sayısı: {products.Count}");
            foreach (var c in campaigns)
                Console.WriteLine($"Kampanya: {c.Name}, ImageUrl: {c.ImageUrl}, IsActive: {c.IsActive}");

            var sliders = campaigns.Select(c => new SliderItem
            {
                Title = c.Name,
                Subtitle = c.Description,
                ImageUrl = c.ImageUrl ?? "slide-1.jpg"
            }).ToList();

            var gallery = campaigns.Select(c => new GalleryItem
            {
                ImageUrl = c.ImageUrl ?? "gallery-1.jpg",
                AltText = c.Name
            }).ToList();

            var testimonials = new List<TestimonialItem>
            {
                new TestimonialItem
                {
                    Name="Jane Doe",
                    Content="Absolutely delicious!",
                    ImageUrl="testimonial-1.png"
                },
                new TestimonialItem
                {
                    Name="John Smith",
                    Content="Amazing bakery!",
                    ImageUrl="testimonial-2.png"
                }
            };

            var model = new HomeIndexViewModel
            {
                Campaigns = campaigns,
                Products = products,
                Sliders = sliders,
                Gallery = gallery,
                Testimonials = testimonials
            };

            return View(model);
        }
    }
}