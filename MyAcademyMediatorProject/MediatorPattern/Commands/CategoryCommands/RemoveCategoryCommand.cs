using MediatR;

namespace MyAcademyMediatorProject.MediatorPattern.Commands.CategoryCommands
{
    public record RemoveCategoryCommand(Guid Id) : IRequest
    {
    }
}
