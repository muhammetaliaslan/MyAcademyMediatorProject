using MediatR;

namespace MyAcademyMediatorProject.MediatorPattern.Commands.ProductCommands
{
    public record UpdateProductCommand(Guid Id,
                                      string Name,
                                      decimal Price,
                                      int Stock,
                                      Guid CategoryId) : IRequest
    {
    }
}
