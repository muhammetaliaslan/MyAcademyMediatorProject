using Microsoft.AspNetCore.Mvc;
using MediatR;
using MyAcademyMediatorProject.MediatorPattern.Queries.ProductQueries;
using MyAcademyMediatorProject.MediatorPattern.Results.ProductResult;

namespace MyAcademyMediatorProject.Areas.User.ViewComponents
{
    public class ShopViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public ShopViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            return View(products);
        }
    }
}