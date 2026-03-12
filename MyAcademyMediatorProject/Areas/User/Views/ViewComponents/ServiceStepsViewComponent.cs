using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MyAcademyMediatorProject.ViewComponents
{
    public class ServiceStepsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // İster static veri, ister db’den çek
            var steps = new[]
            {
                new { Step = 1, Title = "Choose Product", Description = "Select your favorite bakery items" },
                new { Step = 2, Title = "Place Order", Description = "Add items to cart and checkout" },
                new { Step = 3, Title = "Receive Order", Description = "We deliver at your doorstep" }
            };

            return View(steps);
        }
    }
}