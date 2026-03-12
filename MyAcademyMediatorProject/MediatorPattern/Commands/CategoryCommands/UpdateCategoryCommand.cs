using MediatR;

namespace MyAcademyMediatorProject.MediatorPattern.Commands.CategoryCommands
{
    public record UpdateCategoryCommand(string Name, Guid Id) : IRequest
    {
    }
}
