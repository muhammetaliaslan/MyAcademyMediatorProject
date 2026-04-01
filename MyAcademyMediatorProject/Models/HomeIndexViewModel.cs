using MyAcademyMediatorProject.MediatorPattern.Results.CampaignResults;
using MyAcademyMediatorProject.MediatorPattern.Results.ProductResult;
using System.Collections.Generic;

namespace MyAcademyMediatorProject.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<GetCampaignsQueryResult> Campaigns { get; set; } = new List<GetCampaignsQueryResult>();
        public IEnumerable<GetProductsQueryResult> Products { get; set; } = new List<GetProductsQueryResult>();
        public IEnumerable<SliderItem> Sliders { get; set; } = new List<SliderItem>();
        public IEnumerable<GalleryItem> Gallery { get; set; } = new List<GalleryItem>();
        public IEnumerable<TestimonialItem> Testimonials { get; set; } = new List<TestimonialItem>();
    }

    public class SliderItem
    {
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string BgColor { get; set; } = "#FFA500"; // default turuncu
    }

    public class GalleryItem
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string AltText { get; set; } = string.Empty;
    }

    public class TestimonialItem
    {
        public string Name { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}