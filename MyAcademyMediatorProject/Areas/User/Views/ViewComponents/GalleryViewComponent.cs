using Microsoft.AspNetCore.Mvc;

namespace MyAcademyMediatorProject.Areas.User.ViewComponents
{
    public class GalleryViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Örnek sabit görseller, sonradan Cloud Storage ile değiştir
            var photos = new List<string>
            {
                "~/bagery/images/gallery1.jpg",
                "~/bagery/images/gallery2.jpg",
                "~/bagery/images/gallery3.jpg"
            };
            return View(photos);
        }
    }
}