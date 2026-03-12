using Microsoft.AspNetCore.Mvc;
using MyAcademyMediatorProject.Patterns.Observer;
using System.Threading.Tasks;

namespace MyAcademyMediatorProject.Areas.User.ViewComponents
{
    public class ContactViewComponent : ViewComponent
    {
        private readonly ContactSubject _subject;

        public ContactViewComponent(ContactSubject subject)
        {
            _subject = subject;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }

        // Form submit için async metod
        [HttpPost]
        public async Task SubmitMessage(string name, string email, string message)
        {
            await _subject.NotifyAsync(name, email, message); // async çağrı
        }
    }
}