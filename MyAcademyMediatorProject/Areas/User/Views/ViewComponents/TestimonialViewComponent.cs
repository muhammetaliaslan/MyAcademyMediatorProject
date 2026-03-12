using Microsoft.AspNetCore.Mvc;

namespace MyAcademyMediatorProject.Areas.User.ViewComponents
{
    public class TestimonialViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Örnek statik veriler
            var testimonials = new List<(string Name, string Text)>
            {
                ("Ali Aslan", "Great bakery! Loved the bread."),
                ("Selin Aslan", "Delicious pastries and fast delivery.")
            };
            return View(testimonials);
        }
    }
}