using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyAcademyMediatorProject.Context;
using MyAcademyMediatorProject.MediatorPattern.Commands.OrderItemCommands;
using MyAcademyMediatorProject.MediatorPattern.Queries.OrderItemQueries;

namespace MyAcademyMediatorProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderItemController : Controller
    {
        private readonly IMediator _mediator;
        private readonly AppDbContext _context;

        public OrderItemController(IMediator mediator, AppDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        // ✅ INDEX (Listeleme)
        public async Task<IActionResult> Index()
        {
            var orderItems = await _mediator.Send(new GetOrderItemsQuery());
            return View(orderItems);
        }

        // ✅ CREATE GET (Dropdownlar için)
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await FillDropdownsAsync();
            return View();
        }

        // ✅ CREATE POST
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderItemCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        // ✅ UPDATE GET
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var orderItem = await _mediator.Send(new GetOrderItemByIdQuery(id));

            await FillDropdownsAsync(orderItem.OrderId, orderItem.ProductId);

            return View(new UpdateOrderItemCommand
            {
                Id = orderItem.Id,
                OrderId = orderItem.OrderId,
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity,
                UnitPrice = orderItem.UnitPrice
            });
        }

        // ✅ UPDATE POST
        [HttpPost]
        public async Task<IActionResult> Update(UpdateOrderItemCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        // ✅ DELETE
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new RemoveOrderItemCommand(id));
            return RedirectToAction("Index");
        }

        // ✅ Dropdown doldurma metodu
        private async Task FillDropdownsAsync(Guid? selectedOrderId = null, Guid? selectedProductId = null)
        {
            var orders = await _context.Orders.ToListAsync();
            ViewBag.Orders = new SelectList(orders, "Id", "CustomerName", selectedOrderId);

            var products = await _context.Products.ToListAsync();
            ViewBag.Products = new SelectList(products, "Id", "Name", selectedProductId);
        }
    }
}