using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyMediatorProject.MediatorPattern.Commands.OrderCommands;
using MyAcademyMediatorProject.MediatorPattern.Queries.OrderQueries;

namespace MyAcademyMediatorProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Sipariş listesi
        public async Task<IActionResult> Index()
        {
            var orders = await _mediator.Send(new GetOrdersQuery());
            return View(orders);
        }

        // Sipariş detayı
        public async Task<IActionResult> Details(Guid id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery(id));
            return View(order);
        }

        // Sipariş silme
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new RemoveOrderCommand(id));
            return RedirectToAction("Index");
        }
    }
}