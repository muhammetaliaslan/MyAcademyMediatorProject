using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MyAcademyMediatorProject.Areas.User.Components
{
    public class HistoryViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Eğer dinamik veri yoksa View'e null ya da boş model gönder
            return View();
        }
    }
}