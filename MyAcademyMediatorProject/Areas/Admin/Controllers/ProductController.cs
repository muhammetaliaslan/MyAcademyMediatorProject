using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyMediatorProject.MediatorPattern.Commands.ProductCommands;
using MyAcademyMediatorProject.MediatorPattern.Queries.CategoryQueries;
using MyAcademyMediatorProject.MediatorPattern.Queries.ProductQueries;

namespace MyAcademyMediatorProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(IMediator _mediator) : Controller
    {
        private async Task GetCategoriesAsync()
        {
            var categories = await _mediator.Send(new GetCategoriesQuery());
            ViewBag.Categories = (from category in categories
                                  select new SelectListItem
                                  {
                                      Text = category.Name,
                                      Value = category.Id.ToString()
                                  }).ToList();
        }



        public async Task<IActionResult> Index()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            return View(products);
        }

        public async Task<IActionResult> CreateProduct()
        {
            await GetCategoriesAsync();
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");


        }

        public async Task<IActionResult> UpdateProduct(Guid id)
        {
           await GetCategoriesAsync();
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return View(product);
        }

        [HttpPost]

        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _mediator.Send(new RemoveProductCommand(id));
            return RedirectToAction("Index");
        }
    }
}
