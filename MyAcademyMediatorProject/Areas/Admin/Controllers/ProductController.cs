using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyMediatorProject.MediatorPattern.Commands.ProductCommands;
using MyAcademyMediatorProject.MediatorPattern.Queries.CategoryQueries;
using MyAcademyMediatorProject.MediatorPattern.Queries.ProductQueries;

namespace MyAcademyMediatorProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private async Task GetCategoriesAsync()
        {
            var categories = await _mediator.Send(new GetCategoriesQuery());
            ViewBag.Categories = categories
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
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
            // Görsel var mı kontrol et
            if (command.ImageFile != null && command.ImageFile.Length > 0)
            {
                var fileName = Path.GetFileName(command.ImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                                            "wwwroot/Bagery/assets/images/resource/shop", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await command.ImageFile.CopyToAsync(stream);
                }

                // ImageUrl olarak kaydediyoruz
                command = command with { ImageUrl = "/Bagery/assets/images/resource/shop/" + fileName };
            }

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
            // Görsel var mı kontrol et
            if (command.ImageFile != null && command.ImageFile.Length > 0)
            {
                var fileName = Path.GetFileName(command.ImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                                            "wwwroot/Bagery/assets/images/resource/shop", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await command.ImageFile.CopyToAsync(stream);
                }

                command = command with { ImageUrl = "/Bagery/assets/images/resource/shop/" + fileName };
            }

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