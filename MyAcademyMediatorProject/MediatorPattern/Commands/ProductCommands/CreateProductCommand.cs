using MediatR;

namespace MyAcademyMediatorProject.MediatorPattern.Commands.ProductCommands
{
    public record CreateProductCommand(string Name,
                                       decimal Price, 
                                       int Stock,
                                       Guid CategoryId) : IRequest
    {
    }
}
