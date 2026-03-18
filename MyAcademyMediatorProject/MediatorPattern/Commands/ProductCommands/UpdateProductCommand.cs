using MediatR;

namespace MyAcademyMediatorProject.MediatorPattern.Commands.ProductCommands
{
    public record UpdateProductCommand(Guid Id,
                                      string Name,
                                      decimal Price,
                                      int Stock,
                                      string ImageUrl,
                                      IFormFile? ImageFile,
                                      Guid CategoryId) : IRequest
    {
    }
}
