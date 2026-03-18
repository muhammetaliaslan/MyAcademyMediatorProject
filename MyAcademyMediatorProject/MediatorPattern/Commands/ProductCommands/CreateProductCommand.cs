using MediatR;

namespace MyAcademyMediatorProject.MediatorPattern.Commands.ProductCommands
{
    public record CreateProductCommand(string Name,
                                       decimal Price, 
                                       int Stock,
                                       string ImageUrl,
                                       IFormFile? ImageFile,
                                       Guid CategoryId) : IRequest
    {
    }
}
