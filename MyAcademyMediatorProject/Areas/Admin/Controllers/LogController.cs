using Microsoft.AspNetCore.Mvc;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.Repositories;

namespace MyAcademyMediatorProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LogController : Controller
    {
        private readonly IRepository<Log> _repository;

        public LogController(IRepository<Log> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var logs = await _repository.GetAllAsync();
            return View(logs);
        }
    }
}